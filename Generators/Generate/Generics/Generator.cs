using CodeGenerator.Generators.Abstracts;
using Utils.Model.Enums;

namespace CodeGenerator.Generators {

	public static class Generator {

		public static AbstractGenerator? SelectGenerator(Database database) {
			AbstractGenerator? generator = null;
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