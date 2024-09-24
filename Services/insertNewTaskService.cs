using toDo.Interfaces;
namespace toDo.Services
{
    public class insertNewTaskService : INewTask
    {
        private readonly IDapperDBConnectInterface _dbConnect;
        public insertNewTaskService(IDapperDBConnectInterface DapperDbConnect)
        {
            _dbConnect = DapperDbConnect;            
        }
        public string insertNewTask(string name, string description, DateOnly dueDate)
        {
            string query = "insert into [dbo].[NewTable] (TaskName,[Desc],DueDate, Status) values ('"+ name +"','"+description+"', '"+dueDate.ToString("yyyy-MM-dd")+"','New')" ;
            string response = _dbConnect.PostDBQuery(query);    
            return "Task inserted";
        }
    }
}