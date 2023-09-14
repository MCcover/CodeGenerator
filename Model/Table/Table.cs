﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Model.Table {

	public class Table {
		public string Name { get; set; }

		public List<Column>? Columns { get; set; } = null;

		public string ClassName { get; set; } = "";

		public Table(string name) {
			Name = name;
		}
	}
}