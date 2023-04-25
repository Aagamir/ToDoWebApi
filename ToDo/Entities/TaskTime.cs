using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;

namespace ToDo.Entities
{
    public class TaskTime
    {
        public int Id { get; set; }
        public TaskProgress TaskProgress { get; set; }
        public DateTime Time { get; set; }
        public int TaskId { get; set; }
    }
}