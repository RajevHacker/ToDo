using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using toDo.Interfaces;
using toDo.Models;

namespace toDo.Services
{
    public class openTaskService : IOpenTasks
    {
        private readonly IDapperDBConnectInterface _dbConnect;
        public openTaskService(IDapperDBConnectInterface DapperDbConnect)
        {
            this._dbConnect = DapperDbConnect;
        }

        public List<openTask> OpenTask()
        {
            string query = "select TaskName, DueDate from [master].[dbo].[NewTable] where Status = 'New'";
            using(var connection = this._dbConnect.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Database connection could not be created.");
                }

                // Check for null result from the query
                List<openTask> openTasks = connection.Query<openTask>(query).ToList() ?? new List<openTask>();
                return openTasks;
            }
        }

    }
}