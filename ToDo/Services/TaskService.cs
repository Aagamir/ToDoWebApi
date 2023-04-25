using AutoMapper;
using CharacterSheetApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.Enums;
using ToDo.Models.Dtos;
using ToDo.Services.Interface;

namespace ToDo.Services
{
    public class TaskService : ITaskService
    {
        private readonly Context _context;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public TaskService(Context context, IUserContextService userContextService, IMapper mapper)
        {
            _context = context;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public int CreateTask(CreateTaskDto dto)
        {
            int userId = (int)_userContextService.GetUserId;
            var user = _context.Users.FirstOrDefault(c => c.Id == userId);
            var task = new Entities.Task(); //_mapper.Map<Entities.Task>(dto);
            task.Name = dto.Name;
            task.Description = dto.Description;
            task.TaskProgress = TaskProgress.ToDo;
            task.UserId = user.Id;

            var time = new TaskTime();
            time.Time = DateTime.Now;
            time.TaskProgress = TaskProgress.ToDo;
            task.TaskTimes = new List<TaskTime> { time };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }

        public int ChangeTaskState(TaskProgress progress, int id)
        {
            if (_context.Tasks.FirstOrDefault(w => w.Id == id) is null)
            {
                throw new NotFoundException("Wrong task Id");
            }
            var task = _context.Tasks.FirstOrDefault(c => c.Id == id);
            if (task.UserId != _userContextService.GetUserId)
            {
                throw new ForbiddenException("Nie masz uprawnień");
            }
            task.TaskProgress = progress;
            var time = new TaskTime();
            time.Time = DateTime.Now;
            time.TaskProgress = progress;
            task.TaskTimes = new List<TaskTime> { time };
            _context.SaveChanges();
            return time.Id;
        }

        public List<Entities.Task> GetTasks()
        {
            var userId = _userContextService.GetUserId;
            var user = _context.Users.FirstOrDefault(c => c.Id == userId);
            var tasks = new List<Entities.Task>();
            if (user.Role == Role.Admin)
            {
                var dbTasks = _context.Tasks.Include(c => c.TaskTimes);
                tasks.AddRange(dbTasks);
            }
            else
            {
                var dbTasks = _context.Tasks.Include(c => c.TaskTimes).Where(c => c.UserId == userId);
                tasks.AddRange(dbTasks);
            }
            return tasks;
        }
    }
}