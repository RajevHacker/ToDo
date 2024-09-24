using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDo.Models
{
    public class toDos
    {
        public string taskName { get; set; }
        public string desc { get; set; }
        public DateOnly dueDate { get; set; }
    }
}