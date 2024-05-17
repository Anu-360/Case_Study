using Project_Management.Model;


namespace Project_Management.Dao
{
    internal interface IProjectRepository
    {
        bool Login(string username,string password);
        bool AddUser(User user);
        bool CreateEmployee(Employee emp);
        bool CreateProject(Project pj);
        bool CreateTask(Model.Task task);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);
        bool DeleteEmployee(int userId);
        bool DeleteTask(int TaskId);
        //List<Model.Task> GetAllTasks(int empId, int projectId);
        List<ProjectTask> GetProjectsAssignedToEmployee(int employeeId);
    }
}
