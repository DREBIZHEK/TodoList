using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class TaskEntity : BaseEntity, IComparable<TaskEntity>
	{
		public bool IsDone = false;
		public int Priority { get; set; }
		public string Text { get; set; }

		public int CompareTo(TaskEntity baseEntity)
		{
			if (this.Priority == baseEntity.Priority)
				return 0;
			else if (this.Priority > baseEntity.Priority)
				return 1;
			else
				return -1;
		}
	}
}
