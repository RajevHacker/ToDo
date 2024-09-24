using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace toDo.Interfaces
{
    public interface IDapperDBConnectInterface
    {
        public IDbConnection CreateConnection();
        public string PostDBQuery(string query);
    }
}