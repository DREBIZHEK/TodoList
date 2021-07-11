using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class TasksModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public string Text { get; set; }
		public bool IsDone { get; set; }

		public TasksModel(string name, int priority, string text)
		{
			Random rng = new Random();
			Id = rng.Next(1,10000);
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Priority = priority;
			Text = text ?? throw new ArgumentNullException(nameof(text));
		}

		public TasksModel()
		{
		}
	}
}
