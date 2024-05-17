
using Project_Management.Constants;

namespace Project_Management.Model
{
    public class Project
    {
        int projectId;
        string ProjectName;
        string Description;
        DateTime Start_date;
        ProjectStatus Status;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        public string Project_Name
        {
            get { return ProjectName; }
            set { ProjectName = value; }
        }
        public string Project_Description
        {
            get { return Description; }
            set { Description = value; }
        }
        public DateTime StartDate
        {
            get { return Start_date.Date; }
            set { Start_date = value; }
        }
        public ProjectStatus Project_Status
        {
            get { return Status; }
            set { Status = value; }
        }

        public Project()
        {

        }

        public Project(string projectName, string description, DateTime start_date, ProjectStatus status) 
        {
            
           
            Project_Name = projectName;
            Project_Description = description;
            StartDate = start_date;
            Project_Status = status;
        }
        public Project(int projectid,string projectName)
        {
            ProjectId= projectid;
            Project_Name = projectName;
        }
       
      


    }
}
