using Project_Management.Model;
using Project_Management.Dao;
using Project_Management.Service;
using Project_Management.Constants;
using Project_Management.MyExceptions;




namespace Project_Management.ProjectApp
{
   
    internal class Project_App
    {
        readonly IProjectService iprojectService;
        readonly UserService userService;
        readonly ProjectRepositoryImpl projectRepositoryImpl;
        public Project_App()
        {
            projectRepositoryImpl = new ProjectRepositoryImpl();
            iprojectService = new ProjectService();
            userService = new UserService();
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; 
            string header = "Welcome to the Project Management Application!";
            int stringWidth = header.Length;
            int space = ((Console.WindowWidth) / 2) + (stringWidth / 2);
            Console.WriteLine(header.PadLeft(space));
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("[1] Login ");
            Console.WriteLine("[2] Register ");
            Console.WriteLine("[3] Exit ");
            Console.WriteLine("Choose an operation: ");
            int userinput = Convert.ToInt32(Console.ReadLine());
            switch (userinput)
            {
                case 1:
                    Console.WriteLine("Enter the username: ");
                    string username= Console.ReadLine();
                    Console.WriteLine("Enter the password(Characters only allowed): ");
                    string password= Console.ReadLine();    
                    if (userService.Login(username,password))
                    {
                       
                        MainMenu();
                    }
                    else
                    {
                        Run();
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter a username: ");
                    string UserName= Console.ReadLine();
                    Console.WriteLine("Enter a password(Characters only allowed): ");
                    string Password=Console.ReadLine(); 
                    Console.WriteLine("Enter an Email address(example@gmail.com): ");
                    string email= Console.ReadLine();
                    bool isValid = User.IsValidEmail(email);
                    userService.RegisterUser(UserName,Password,email);
                    Run();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    Console.WriteLine("Visit Again!");
                    Environment.Exit(0);
                    break;
                default:
                     Console.WriteLine("Invalid user input!");
                    
                    break;
            }
        }
        public void MainMenu()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            string heading = "Project Management App";
            int stringwidth = heading.Length;
            int alot = ((Console.WindowWidth) / 2) + (stringwidth / 2);
            Console.WriteLine(heading.PadLeft(alot));
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("[1] Add Employee");
            Console.WriteLine("[2] Add Project");
            Console.WriteLine("[3] Add Task");
            Console.WriteLine("[4] Assign Project to Employee");
            Console.WriteLine("[5] Assign Task within a Project to Employee");
            Console.WriteLine("[6] Delete Employee");
            Console.WriteLine("[7] Delete Task");
            Console.WriteLine("[8] List all projects assigned with tasks to an employee");
            Console.WriteLine("[9] Exit");
            Console.WriteLine("Choose an Operation: ");
            int input=Convert.ToInt32(Console.ReadLine());
            switch(input) 
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Enter Employee Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Employee Designation: ");
                        string designation = Console.ReadLine();
                        Console.WriteLine("Enter Gender of employee: ");
                        string gender = Console.ReadLine();
                        Console.WriteLine("Enter Salary of employee: ");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        Employee emp = new Employee(name, designation, gender, salary);
                        iprojectService.CreateEmployee(emp);
                    }catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: {e.Message}");   
                    }
                    GoBackToMainMenu();
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Enter Project Name:");
                        string Project_Name = Console.ReadLine();
                        Console.WriteLine("Enter Project Description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter start date:");
                        DateTime start_date = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Project Status [Started,Developed,Build,Tested,Deployed]");
                        Console.WriteLine("Choose the project status: ");
                        string inputstatus = Console.ReadLine();
                        ProjectStatus status;
                        if (Enum.TryParse(inputstatus, true, out status))
                        {
                            Console.WriteLine("Status added");

                        }
                        Project pj = new Project(Project_Name, description, start_date, status);
                        iprojectService.CreateProject(pj);
                    }
                    catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                    GoBackToMainMenu();
                    break;
                    case 3:
                    try
                    {
                        List<Project> project_database = projectRepositoryImpl.GetProjectsFromDatabase();
                        Console.WriteLine("Available Projects:");
                        foreach (Project project in project_database)
                        {
                   
                            Console.WriteLine($"Project ID: {project.ProjectId} \t Name: {project.Project_Name}");
                        }
                        Console.WriteLine("Enter the ID of the project from available projects: ");
                        int projectId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Task Name:");
                        string TaskName = Console.ReadLine();
                        Console.WriteLine("Task Status [Assigned,Started,Completed]");
                        Console.WriteLine("Choose the task status: ");
                        string enuminput = Console.ReadLine();
                        Task_Status TaskStatus;
                        if (Enum.TryParse(enuminput, true, out TaskStatus))
                        {
                            Model.Task taskcreation = new Model.Task(TaskName, projectId, TaskStatus);
                            iprojectService.CreateTask(taskcreation);
                        }
                    }catch(FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);  
                    }
                    GoBackToMainMenu();
                    break;
                case 4:
                    try
                    {
                        List<Project> projects = projectRepositoryImpl.GetProjectsFromDatabase();
                        List<Employee> employees = projectRepositoryImpl.GetEmployeesFromDatabase();


                        Console.WriteLine("Available Projects:");
                        foreach (Project project in projects)
                        {
                            Console.WriteLine($"Project ID: {project.ProjectId} \t Name: {project.Project_Name}");
                        }
                        Console.WriteLine("Enter the ID of the project from available projects: ");
                        int projectid = int.Parse(Console.ReadLine());


                        Console.WriteLine("\nAvailable Employees:");
                        foreach (Employee employee in employees)
                        {
                            Console.WriteLine($"Employee ID: {employee.EmployeeId} \t Name: {employee.Name}");
                        }

                        Console.WriteLine("Enter the ID of the employee from available employees: ");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        iprojectService.AssignProjectToEmployee(projectid, employeeId);
                    }catch(EmployeeNotFoundException e) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                    catch(FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                    GoBackToMainMenu();
                    break;


                case 5:
                    try
                    {
                        List<Project> project1 = projectRepositoryImpl.GetProjectsFromDatabase();
                        List<Employee> employee1 = projectRepositoryImpl.GetEmployeesFromDatabase();
                        List<Model.Task> tasks = projectRepositoryImpl.GetTasksFromDatabase();

                        Console.WriteLine("\nAvailable Tasks: ");
                        foreach (Model.Task task1 in tasks)
                        {
                            Console.WriteLine($"Task ID: {task1.TaskId} \t Name: {task1.TaskName}");
                        }
                        Console.WriteLine("Enter the ID of the task from available tasks:  ");
                        int taskId = int.Parse(Console.ReadLine());


                        Console.WriteLine("Available Projects:");
                        foreach (Project project in project1)
                        {
                            Console.WriteLine($"Project ID: {project.ProjectId} \t Name: {project.Project_Name}");
                        }

                        Console.WriteLine("Enter the ID of the project from available projects: ");
                        int project_id = int.Parse(Console.ReadLine());


                        Console.WriteLine("\nAvailable Employees:");
                        foreach (Employee employee in employee1)
                        {
                            Console.WriteLine($"Employee ID: {employee.EmployeeId} \t Name: {employee.Name}");
                        }

                        Console.WriteLine("Enter the ID of the employee from available employees: ");
                        int employee_Id = Convert.ToInt32(Console.ReadLine());
                        iprojectService.AssignTaskInProjectToEmployee(taskId, project_id, employee_Id);
                    }catch(ProjectNotFoundException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);   
                    }
                    catch(FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                    GoBackToMainMenu();
                    
                    break;




                case 6:
                    try
                    {
                        List<Employee> listemp = projectRepositoryImpl.GetEmployeesFromDatabase();
                        Console.WriteLine("\nAvailable Employees:");
                        foreach (Employee employee in listemp)
                        {
                            Console.WriteLine($"Employee ID: {employee.EmployeeId} \t Name: {employee.Name}");
                        }
                        Console.WriteLine("Enter the ID of the employee to be deleted: ");
                        int employeeid = Convert.ToInt32(Console.ReadLine());
                        iprojectService.DeleteEmployee(employeeid);
                      
                    }
                    catch(EmployeeNotFoundException e) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                    catch(FormatException ex) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }

                   GoBackToMainMenu();
                    
                    break;

                case 7:
                    try
                    {
                        List<Model.Task> task = projectRepositoryImpl.GetTasksFromDatabase();
                        Console.WriteLine("\nAvailable Tasks:");
                        foreach (Model.Task task1 in task)
                        {
                            Console.WriteLine($"Task ID: {task1.TaskId} \t Name: {task1.TaskName}");
                        }
                        Console.WriteLine("Enter the ID of the task to be deleted: ");
                        int taskid = Convert.ToInt32(Console.ReadLine());
                        iprojectService.DeleteTask(taskid);
                    }
                    catch(Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                   

                    GoBackToMainMenu();
                    break;

                case 8:
                    try
                    {
                        List<Employee> employeedb = projectRepositoryImpl.GetEmployeesFromDatabase();
                        Console.WriteLine("\nAvailable Employees:");
                        foreach (Employee employee in employeedb)
                        {
                            Console.WriteLine($"Employee ID: {employee.EmployeeId} \t Name: {employee.Name}");
                        }
                        Console.WriteLine("Enter the Employee ID from available employees: ");
                        int empid = Convert.ToInt32(Console.ReadLine());
                        iprojectService.GetProjectsAssignedToEmployee(empid);
                    
                    }catch(EmployeeNotFoundException ex) 
                    {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine(ex.Message);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                    GoBackToMainMenu();
                    break;
                    


                case 9:
                   
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Visit Again!");
                    Environment.Exit(0);
                    GoBackToMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;

            }
           void GoBackToMainMenu()
            {
                Console.ForegroundColor= ConsoleColor.Cyan;   
                Console.WriteLine("\nReturn to the Main Menu");
               
                Console.ReadKey();
                MainMenu();
            }
        }
      





















       

          

            }
        }
    

