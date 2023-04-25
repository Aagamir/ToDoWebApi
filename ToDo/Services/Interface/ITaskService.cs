using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;
using ToDo.Models.Dtos;

namespace ToDo.Services.Interface
{
    public interface ITaskService
    {
        int CreateTask(CreateTaskDto dto);

        int ChangeTaskState(TaskProgress progress, int id);

        List<Entities.Task> GetTasks();

        void DeleteTask(int id);
    }
}