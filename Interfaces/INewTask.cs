using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDo.Interfaces
{
    public interface INewTask
    {
        public string insertNewTask(string name, string description, DateOnly dueDate);
    }
}