using Project_Management.Model;
using Project_Management.Dao;
using Project_Management.Model;
using Project_Management.MyExceptions;

using Project_Management.Constants;
using Microsoft.EntityFrameworkCore;



namespace Project_Management.Service
{
    internal class ProjectService : IProjectService
    {
        readonly IProjectRepository projectRepository;

        public ProjectService()
        {
            projectRepository = new ProjectRepositoryImpl();
        }
     
        public bool CreateEmployee(Employee emp)
        {
           
            bool NewEmployee=projectRepository.CreateEmployee(emp);
            if (NewEmployee==true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee Data created successfully!");
            }
            return NewEmployee;
           
        }
        public bool CreateProject(Project pj)
        {
            bool NewProject=projectRepository.CreateProject(pj);
            string input=Console.ReadLine();
           
                if (NewProject == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Project created successfully!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("Project creation failed!");
                }

            return NewProject;
        }
        public bool CreateTask(Model.Task task)
        {
            bool NewTask=projectRepository.CreateTask(task);
            if (NewTask==true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task created successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Task creation failed!");
            }
            return NewTask;
        }
        public bool AssignProjectToEmployee(int projectId, int employeeId)
        { 
       
            bool assigned = projectRepository.AssignProjectToEmployee(projectId, employeeId);
            
            if (assigned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Project assigned to employee successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new EmployeeNotFoundException("Employee data not found!");
            }
            return assigned;
        }
        public bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId)
        {
            bool assigned = projectRepository.AssignTaskInProjectToEmployee(taskId,projectId, employeeId);

            if (assigned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task assigned to project successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ProjectNotFoundException("Project ID not found!");
            }
            return assigned;
        }
        public bool DeleteEmployee(int userId)
        {
            bool deleted = projectRepository.DeleteEmployee(userId);
            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new EmployeeNotFoundException("Employee id not found!");
            }
            return deleted;
        }
        public bool DeleteTask(int TaskId)
        {
            bool deleted = projectRepository.DeleteTask(TaskId);
            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Task not found!");
            }
            return deleted;
        }
        public List<ProjectTask> GetProjectsAssignedToEmployee(int employeeId)
        {
               Employee employee=new Employee();

                List<ProjectTask> projectTasks = projectRepository.GetProjectsAssignedToEmployee(employeeId);

            //if (employeeId != employee.EmployeeId)
            //{
            //    Console.WriteLine("Invalid employee id");

                if (projectTasks.Count > 0)
                {
                    Console.WriteLine("\nProjects and tasks assigned to Employee:");

                    foreach (var projectTask in projectTasks)
                    {
                        Console.WriteLine($"Project ID: {projectTask.Id}, Project Name: {projectTask.ProjectName}, Task ID: {projectTask.Task_id}, Task Name: {projectTask.Task_name}");
                    }
                }
           // }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No projects assigned to this employee");
            }
           
            
            return projectTasks;
        }



    }
}
            
           
           
        




    
         
        
        
        


    

