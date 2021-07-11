using Mappers;
using Models;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
	public class TasksController
	{
		public readonly ITaskService _taskService;

		public TasksController(ITaskService taskService)
		{
			_taskService = taskService;
		}
		public void AddTask(TasksModel task)
		{
			_taskService.AddTask(task.ToDomain());
		}

		public void DeleteTaskById(int id)
		{
			_taskService.DeleteTaskById(id);
		}

		public List<TasksModel> GetAllTasks()
		{
			List<TasksModel> list = new List<TasksModel>();
			foreach (var item in _taskService.GetAllTasks())
			{
				list.Add(item.ToModel());
			}
			return list;
		}

		public TasksModel GetTaskById(int id) => _taskService.GetTaskById(id).ToModel();

		public void ShowAllTasks()
		{
			_taskService.ShowAllTasks();
		}
		public void SortByPriority()
		{
			_taskService.SortByPriority();
		}
		public void MarkExecution(int id)
		{
			_taskService.MarkExecution(id);
		}
		public void FindByName(string name)
		{
			_taskService.FindByName(name);
		}
	}
}
