
using Xunit;

namespace LoanManagementSystem.TestTools.Infrastructure.DataBaseConfig.Integration.
    Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    protected static EfDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;


        return new EfDataContext(
            $"server=.;database=LoanManagementSystem;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");
    }
}