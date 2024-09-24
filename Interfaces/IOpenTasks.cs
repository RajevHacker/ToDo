using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDo.Models;

namespace toDo.Interfaces
{
    public interface IOpenTasks
    {
        public List<openTask> OpenTask();
    }
}