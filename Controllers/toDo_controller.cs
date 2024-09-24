using Microsoft.AspNetCore.Mvc;
using toDo.Interfaces;
using toDo.Models;
namespace toDo.Controllers
{
    [ApiController]
    public class toDo_controller : ControllerBase
    {
        private readonly IDapperDBConnectInterface _IDapperDBConnect;
        private readonly INewTask _InewTask;
        private readonly ICloseTask _IcloseTask;
        private readonly IOpenTasks _IopenTask;
        public toDo_controller(IDapperDBConnectInterface IDapperConnect, INewTask InewTask, ICloseTask IcloseTask, IOpenTasks IopenTask)
        {
            _IDapperDBConnect = IDapperConnect;
            _InewTask = InewTask;
            _IcloseTask = IcloseTask;
            _IopenTask = IopenTask;
        }
       [HttpPost()]
       [Route("toDo/InsertNewTask")] 
       public string newTask([FromHeader] string taskName,[FromHeader] string description, [FromHeader] DateOnly dueDate)
       {
            string response = _InewTask.insertNewTask(taskName,description,dueDate); 
            return response;
       }
       [HttpPost()]
       [Route("toDo/TaskClosure")]
       public string taskClosure([FromHeader] int taskNumber)
       {
            string response = _IcloseTask.closeTask(taskNumber);
            return response;
       }
       [HttpGet()]
       [Route("toDo/OpenTask")]
       public List<openTask> openTask()
       {
            List<openTask> openTasks= _IopenTask.OpenTask();
            return openTasks;
       }
    }
}