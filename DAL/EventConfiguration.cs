using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace MVCEventScheduler.DAL
{
    public class EventConfiguration : DbConfiguration
    {
        public EventConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}