﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Task
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public string Text { get; set; }
		public bool IsDone { get; set; }

	}
}
