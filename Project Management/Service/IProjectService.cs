using Project_Management.Model;


namespace Project_Management.Service
{
    internal interface IProjectService
    {
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
