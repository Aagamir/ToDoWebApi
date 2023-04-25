using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;

namespace ToDo.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskProgress TaskProgress { get; set; }
        public int UserId { get; set; }

        public List<TaskTime> TaskTimes { get; set; }
    }
}