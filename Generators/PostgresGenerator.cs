using CodeGenerator.Generators.Abstracts;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators {

	public class PostgresGenerator : AbstractGenerator {
		public override void Generate(List<Table> tables) {
			foreach (var table in tables) {

				var model = GenerateModel(table);
				var constructor = GenerateConstructor(table);
				var service = GenerateService(table);
				var persistence = GeneratePersistence(table);

				GenerateFolderStructure(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), new GeneratedFileInfo(table, model, constructor, service, persistence));
			}
		}

		public override string GeneratePersistence(Table table) {
			return "Empty Persistence";
		}

		public override string ConvertTypeBdToCSharp(string typeBd) {
			var type = "";
			switch (typeBd) {
				case "bit":
				case "bool":
					type = "bool";
					break;

				case "bytea":
					type = "byte[]";
					break;

				case "date":
				case "timestamp":
				case "timetz":
				case "timestamptz":
					type = "DateTime";
					break;

				case "numeric":
				case "money":
					type = "decimal";
					break;

				case "float8":
					type = "double";
					break;

				case "float4":
					type = "float";
					break;

				case "uuid":
					type = "Guid";
					break;

				case "int4":
					type = "int";
					break;

				case "int8":
					type = "long";
					break;

				case "int2":
					type = "short";
					break;

				case "bpchar":
				case "json":
				case "text":
				case "varchar":
					type = "string";
					break;

				case "interval":
				case "time":
					type = "TimeSpan";
					break;
			}
			return type;
		}

	}
}