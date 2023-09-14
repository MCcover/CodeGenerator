using CodeGenerator.Generators.Interfaces;
using CodeGenerator.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generators {

	public static class Generator {

		public static IGenerator? SelectGenerator(Database database) {
			IGenerator? generator = null;
			switch (database) {
				case Database.Postgres:
					generator = new PostgresGenerator();
					break;

				default:
					throw new Exception("No has Generator defined to this Database");
			}
			return generator;
		}
	}
}