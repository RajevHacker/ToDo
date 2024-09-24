using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDo.Interfaces;

namespace toDo.Services
{
    public class closeTaskService: ICloseTask
    {
        private readonly IDapperDBConnectInterface _dbConnect;
        public closeTaskService(IDapperDBConnectInterface DapperDbConnect)
        {
            _dbConnect = DapperDbConnect;
        }
        
        public string closeTask(int taskNumber)
        {
            string query = "UPDATE [dbo].[NewTable] SET Status = 'Done' where TaskNumber = " + taskNumber;
            string response = _dbConnect.PostDBQuery(query);
            return "Task Closed";
        }        
    }
}