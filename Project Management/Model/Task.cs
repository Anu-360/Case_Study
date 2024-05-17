
using Project_Management.Constants;


namespace Project_Management.Model
{
    public  class Task
    {
        int task_id;
        string task_name;
        int project_id;
        int employee_id;
        Task_Status Status;

        public int TaskId
        {
            get { return task_id; }
            private set { task_id = value; }
        }
        public string TaskName
        {
            get { return task_name; }
            set { task_name = value; }
        }
        public int ProjectId
        {
            get { return project_id; }
            set { project_id = value; }
        }
        public int EmployeeId
        {
            get { return employee_id; }
            set { employee_id = value; }
        }
        public Task_Status TaskStatus
        {
            get { return Status; }
            set {  Status = value; }
        }
        public Task()
        {

        }
        public Task(string task_name,int project_id,int employee_id,Task_Status status)
        {
            task_id++;
            TaskId = task_id;
            TaskName = task_name;
            ProjectId = project_id;
            EmployeeId = employee_id;
            TaskStatus = status;
        }
        public Task(string task_name, int project_id,Task_Status status)
        {
          
            TaskName = task_name;
            ProjectId = project_id;
            TaskStatus =status;
        }
        public Task(int task_id,string task_name)
        {
            TaskId = task_id;
            TaskName = task_name;
        }
    }
}
