using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BWay.Infra.Data
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration config)
        {
            Connection = new SqlConnection(config.GetSection("connectionString").Value);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
