using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Abstract
{
	public interface ITaskRepository
	{
		void AddTask(TaskEntity task);
		void DeleteTaskById(int id);
		TaskEntity GetTaskById(int id);
		List<TaskEntity> GetAllTasks();
		void SortByPriority();
		void MarkExecution(int id);
		void UpdateList();
		void UploadData();

	}
}
