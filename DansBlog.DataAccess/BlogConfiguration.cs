using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;

namespace DansBlog.DataAccess
{
    public class BlogConfiguration : DbConfiguration
    {
        public BlogConfiguration()
        {
            SetProviderServices(
                SqlCeProviderServices.ProviderInvariantName,
                SqlCeProviderServices.Instance
                );
            SetDefaultConnectionFactory(
                new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName)
                );
            SetDatabaseInitializer(new BlogDataInitializer());
        }
    }
}