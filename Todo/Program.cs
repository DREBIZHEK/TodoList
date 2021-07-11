using API;
using DATA;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
	class Program
	{
		static void Main(string[] args)
		{
			string key = "";
			int id;
			TasksController tasksController = new TasksController(new TaskService(new TaskRepository()));


			while (key != "D0")
			{
			Console.WriteLine("Control:" +
				"\n1: Add new task" +
				"\n2: Remove task by id" +
				"\n3: Show all tasks" +
				"\n4: Mark execution" +
				"\n5: Find by name" +
				"\n0: Exit");
				key = Console.ReadKey().Key.ToString();
				Console.WriteLine();
				switch (key)
				{
					case "D1":
						Console.Clear();
						Console.Write("\nName:");
						string name = Console.ReadLine();

						Console.Write("\nPriority:");
						int priority;
						if (!int.TryParse(Console.ReadLine(), out priority))
							throw new ArgumentException("Priority must be a number");

						Console.Write("\nText:");
						string text = Console.ReadLine();

						tasksController.AddTask(new Models.TasksModel(name, priority, text));

						break;
					case "D2":
						Console.Clear();
						Console.Write("\nId:");
						if (!int.TryParse(Console.ReadLine(), out id))
							throw new ArgumentException("Priority must be a number");
						tasksController.DeleteTaskById(id);

						break;
					case "D3":
						Console.Clear();
						tasksController.ShowAllTasks();
						Console.WriteLine("1: Sort" +
							"\n0: Exit");
						if (Console.ReadKey().Key.ToString() == "D1")
						{
							tasksController.SortByPriority();
							tasksController.ShowAllTasks();
						}
						Console.WriteLine();
						break;
					case "D4":
						Console.Clear();
						Console.Write("\nId of the executed task: ");
						if (!int.TryParse(Console.ReadLine(), out id))
							throw new ArgumentException("Priority must be a number");
						tasksController.MarkExecution(id);
						break;
					case "D5":
						Console.Clear();
						Console.Write("\nSearched name: ");
						tasksController.FindByName(Console.ReadLine());
						break;
					default:
						break;
				}
			}
		}
	}
}
