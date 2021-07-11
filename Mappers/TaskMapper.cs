using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mappers
{
	public static class TaskMapper
	{
		public static TaskEntity ToEntity(this Task task)
		{
			return new TaskEntity
			{
				Id = task.Id,
				Name = task.Name,
				Priority = task.Priority,
				Text = task.Text,
				IsDone = task.IsDone
				

			};
		}

		public static Task ToDomain(this TaskEntity task)
		{
			return new Task
			{
				Id = task.Id,
				Name = task.Name,
				Priority = task.Priority,
				Text = task.Text,
				IsDone = task.IsDone

			};
		}
		public static Task ToDomain(this TasksModel task)
		{
			return new Task
			{
				Id = task.Id,
				Name = task.Name,
				Priority = task.Priority,
				Text = task.Text,
				IsDone = task.IsDone

			};
		}

		public static TasksModel ToModel(this Task task)
		{
			return new TasksModel 
			{ 
				Id = task.Id,
				Name = task.Name,
				Priority = task.Priority,
				Text = task.Text,
				IsDone = task.IsDone
			};
		}
	}
}
