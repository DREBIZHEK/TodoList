using DATA.Abstract;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class TaskRepository : ITaskRepository
	{
		private const string path = "Tasks.txt";

		private static List<TaskEntity> list = new List<TaskEntity>();

		public void AddTask(TaskEntity task)
		{
			using (StreamWriter sw = new StreamWriter(path, true))
			{
				sw.WriteLine(JsonConvert.SerializeObject(task));
				sw.WriteLine("end");
			}
		}

		public void DeleteTaskById(int id)
		{
			bool success = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Id == id)
				{
					list.RemoveAt(i);
					success = true;
				}
			}
			if (success)
			{
				Console.WriteLine("Deletion was successful");
				UploadData();
			}
			else
			{
				Console.WriteLine("The specified id was not found");
			}
		}

		public List<TaskEntity> GetAllTasks()
		{
			UpdateList();
			return list;
		}

		public TaskEntity GetTaskById(int id)
		{
			UpdateList();
			foreach (var item in list)
			{
				if (item.Id == id)
				{
					return item;
				}
			}
			throw new ArgumentException("The specified id does not exist");
		}

		public void MarkExecution(int id)
		{
			UpdateList();
			bool success = false;

			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Id == id)
				{
					list[i].IsDone = true;
					success = true;
				}
			}
			if (success)
			{
				Console.WriteLine("Task is done!");
				UploadData();
			}
			else
			{
				Console.WriteLine("The specified task was not found");
			}
		}

		public void SortByPriority()
		{
			list.Sort();
			UploadData();
		}

		public void UpdateList()
		{
			List<TaskEntity> listTemp = new List<TaskEntity>();
			string task = "";
			using (StreamReader sr = new StreamReader(path))
			{
				string line;
				while (!sr.EndOfStream)
				{
					line = sr.ReadLine();
					if (line != "end")
					{
						task += line;
						task += "\n";
					}
					else
					{
						listTemp.Add(JsonConvert.DeserializeObject<TaskEntity>(task));
						task = "";
					}
				}
			}
			list = listTemp;
		}

		public void UploadData()
		{
			File.Delete(path);
			for (int i = 0; i < list.Count; i++)
			{
				AddTask(list[i]);
			}
		}
	}
}

