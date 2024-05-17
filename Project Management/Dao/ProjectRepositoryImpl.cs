using Project_Management.Utility;

using System.Data.SqlClient;
using Project_Management.Model;
using Project_Management.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Project_Management.MyExceptions;


namespace Project_Management.Dao
{
    public class ProjectRepositoryImpl : IProjectRepository
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public ProjectRepositoryImpl()
        {
            sqlConnection = new SqlConnection("Server=OBLIVIATE7;Database=ProjectManagementSystem;Trusted_Connection=True");
            cmd = new SqlCommand();

        }
        public bool Login(string username, string password)
        {


            cmd.CommandText = "SELECT COUNT(*) FROM [User] WHERE Username = @User_name AND Password = @Pass_word";
            cmd.Parameters.AddWithValue("@User_name", username);
            cmd.Parameters.AddWithValue("@Pass_word", password);
            try
            {
                cmd.Connection = sqlConnection;
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                object result = cmd.ExecuteScalar();

                int count = Convert.ToInt32(result);

                return count > 0;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                return false;
            }


        }


        public bool AddUser(User user)
        {


            cmd.CommandText = "INSERT INTO [User] (Username, Password,Email) VALUES (@User_name, @Pass_word,@email)";

            cmd.Parameters.AddWithValue("@User_name", user.Username);
            cmd.Parameters.AddWithValue("@Pass_word", user.Password);
            cmd.Parameters.AddWithValue("@email", user.Email);
            try
            {
                cmd.Connection = sqlConnection;
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(ex.Message);
                return false;
            }




        }
        public bool CreateEmployee(Employee emp)
        {

            cmd.CommandText = "INSERT INTO Employee(name,Designation,Gender,Salary) VALUES(@Name, @Designation, @Gender, @Salary)";
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Designation", emp.Emp_Designation);
            cmd.Parameters.AddWithValue("@Gender", emp.Emp_Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Emp_Salary);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;

        }
        public bool CreateProject(Project pj)
        {
            cmd.CommandText = "INSERT INTO Project(ProjectName,Description,[Start date],Status) VALUES(@Projectname, @Description, @Startdate,@Status)";
            cmd.Parameters.AddWithValue("@Projectname", pj.Project_Name);
            cmd.Parameters.AddWithValue("@Description", pj.Project_Description);
            cmd.Parameters.AddWithValue("@Startdate", pj.StartDate);
            cmd.Parameters.AddWithValue("@Status", pj.Project_Status);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public List<Project> GetProjectsFromDatabase()
        {
            cmd.Parameters.Clear(); 
            List<Project> projects = new List<Project>();


            cmd.CommandText = "SELECT Id, ProjectName FROM Project";

            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int projectId = reader.GetInt32(0);
                string projectName = reader.GetString(1);

                Project project = new Project(projectId, projectName);
                projects.Add(project);
            }

            reader.Close();
            return projects;
        }
        public List<Employee> GetEmployeesFromDatabase()
        {
            cmd.Parameters.Clear();
            List<Employee> employees = new List<Employee>();


            cmd.CommandText = "SELECT id, name FROM Employee";


            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int employeeId = reader.GetInt32(0);
                string Name = reader.GetString(1);

                Employee employee = new Employee(employeeId, Name);
                employees.Add(employee);
            }

            reader.Close();
            return employees;
        }
        public List<Model.Task> GetTasksFromDatabase()
        {
            cmd.Parameters.Clear();
            List<Model.Task> tasks = new List<Model.Task>();


            cmd.CommandText = "SELECT task_id, task_name FROM Task";


            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int TaskId = reader.GetInt32(0);
                string TaskName = reader.GetString(1);

                Model.Task task = new Model.Task(TaskId, TaskName);
                tasks.Add(task);
            }

            reader.Close();
            return tasks;
        }




        public bool CreateTask(Model.Task task)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Task(task_name,project_id,Status) VALUES(@Taskname,@Projectid,@Status)";
            cmd.Parameters.AddWithValue("@Taskname", task.TaskName);
            cmd.Parameters.AddWithValue("@Projectid", task.ProjectId);
            cmd.Parameters.AddWithValue("@Status", task.TaskStatus);
            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Employee SET project_id = @ProjectId WHERE id = @EmployeeId";
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);


            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;


        }


        public bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Task SET project_id = @ProjectId,employee_id=@EmpId WHERE task_id=@Taskid";
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            cmd.Parameters.AddWithValue("@EmpId", employeeId);
            cmd.Parameters.AddWithValue("@Taskid", taskId);


            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;


        }
        public bool DeleteEmployee(int userId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Employee WHERE id = @UserId";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool DeleteTask(int TaskId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Task WHERE task_id = @TaskId";
            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            cmd.Connection = sqlConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
     

        public List<ProjectTask> GetProjectsAssignedToEmployee(int employeeId)
        {
            cmd.Parameters.Clear();
            List<ProjectTask> projecttask = new List<ProjectTask>();
            

            cmd.CommandText = @"
                SELECT t.task_id, t.task_name, p.Id, p.ProjectName
                FROM Task t
                JOIN Project p ON t.project_id = p.Id
                WHERE t.employee_id = @EmpId";
            cmd.Parameters.AddWithValue("@EmpId", employeeId);
            
                cmd.Connection = sqlConnection;

                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projecttask.Add(new ProjectTask
                        {
                             Id= reader.GetInt32(0),
                             ProjectName= reader.GetString(1),
                             Task_id= reader.GetInt32(2),
                             Task_name= reader.GetString(3),


                        });
                        
                    
                }

                sqlConnection.Close();
            }

            return projecttask;
        }



    }
}

    



    

