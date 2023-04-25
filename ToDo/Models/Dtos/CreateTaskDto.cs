using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;

namespace ToDo.Models.Dtos
{
    public class CreateTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}