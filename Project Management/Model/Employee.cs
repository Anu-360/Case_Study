

namespace Project_Management.Model
{
    public  class Employee
    {
        int empId;
        string name;
        string Designation;
        string Gender;
        decimal Salary;
        int project_id;
       
        public int EmployeeId
        {
            get { return empId; }
            set { empId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Emp_Designation
        {
            get { return Designation; }
            set { Designation = value; }
        }

        public string Emp_Gender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public decimal Emp_Salary
        {
            get { return Salary; }
            set { Salary = value; }
        }

        public int ProjectId
        {
            get { return project_id; }
            set { project_id = value; }
        }
        public Employee()
        {

        }
        public Employee(string name,string Designation,string Gender,decimal Salary)
        {
            
           
            Name = name;
            Emp_Designation = Designation;
            Emp_Gender = Gender;
            Emp_Salary = Salary;
            //ProjectId = project_id;    
        }
        public Employee(int employeeid,string name)
        {
            EmployeeId = employeeid;
            Name = name;
        }

        public override string ToString()
        {
            return $"Employee ID : {EmployeeId}\n Employee Name : {Name}\n Designation : {Emp_Designation}\n Gender : {Gender}\n Salary : {Salary}\n Project ID :{ProjectId}";



        }


    }
}
