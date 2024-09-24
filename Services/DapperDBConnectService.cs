using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using toDo.Interfaces;
namespace toDo.Services
{
    public class DapperDBConnectService : IDapperDBConnectInterface
    {
        private readonly string _ConnectionString;
        public DapperDBConnectService(IConfiguration config)
        {
            _ConnectionString = config.GetConnectionString("DbConnection");
        }
        
        public IDbConnection CreateConnection() => new SqlConnection(_ConnectionString);
        public string PostDBQuery(string query)
        {
            using(var connection = CreateConnection())
            {
                connection.Query(query);
            }
            return "Updated the Data base";
        }
        
    }
}