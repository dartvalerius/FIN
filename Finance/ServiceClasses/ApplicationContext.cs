using System.Data.Entity;

namespace Finance.ServiceClasses
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {

        }
    }
}