

namespace Project_Management.MyExceptions
{
    public  class EmployeeNotFoundException:ApplicationException
    {
        public EmployeeNotFoundException() 
        { 

        }  

        public EmployeeNotFoundException(string message) : base(message)
        {

        }
    }
}
