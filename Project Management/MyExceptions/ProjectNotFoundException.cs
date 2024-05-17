

namespace Project_Management.MyExceptions
{
    public  class ProjectNotFoundException:ApplicationException
    {
        public ProjectNotFoundException()
        {

        }
        public ProjectNotFoundException(string message) : base(message)
        {

        }
    }
}
