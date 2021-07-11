using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Abstract
{
	public interface ITaskService
	{
		void AddTask(Task task);
		void DeleteTaskById(int id);
		Task GetTaskById(int id);
		List<Task> GetAllTasks();
		void ShowAllTasks();
		void SortByPriority();
		void MarkExecution(int id);
		void FindByName(string name);
	}
}
