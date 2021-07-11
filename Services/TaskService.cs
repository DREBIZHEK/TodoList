using Mappers;
using DATA.Abstract;
using Domain;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _taskRepository;
		public TaskService(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}
		public void AddTask(Task task)
		{
			_taskRepository.AddTask(task.ToEntity());
		}

		public void DeleteTaskById(int id)
		{
			_taskRepository.DeleteTaskById(id);
		}

		public List<Task> GetAllTasks()
		{
			List<Task> list = new List<Task>();
			foreach (var item in _taskRepository.GetAllTasks())
			{
				list.Add(item.ToDomain());
			}
			return list;
		}

		public Task GetTaskById(int id) => _taskRepository.GetTaskById(id).ToDomain();

		public void ShowAllTasks()
		{
			string status;
			foreach (var item in GetAllTasks())
			{
				if (item.IsDone)
				{
					status = "Done";
				}
				else
				{
					status = "In progress";
				}
				Console.WriteLine($"Id:{item.Id}" +
					$"\nName: {item.Name}" +
					$"\nPriority: {item.Priority}" +
					$"\nStatus: {status}" +
					$"\nText:\n{item.Text}\n");
			}
		}
		public void SortByPriority()
		{
			_taskRepository.SortByPriority();
		}
		public void MarkExecution(int id)
		{
			_taskRepository.MarkExecution(id);
		}

		public void FindByName(string name)
		{
			bool check = false;
			foreach (var item in GetAllTasks())
			{
				if (item.Name == name)
				{
					check = true;
					string status;
					if (item.IsDone)
					{
						status = "Done";
					}
					else
					{
						status = "In progress";
					}
					Console.WriteLine($"Id:{item.Id}" +
					$"\nName: {item.Name}" +
					$"\nPriority: {item.Priority}" +
					$"\nStatus: {status}" +
					$"\nText:\n{item.Text}\n");
				}
			}
			if (!check)
			{
				Console.WriteLine("Task with this name does not exist");
			}
		}
	}
}
