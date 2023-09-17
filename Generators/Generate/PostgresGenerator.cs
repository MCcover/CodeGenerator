using CodeGenerator.Generators.Abstracts;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators {

	public class PostgresGenerator : AbstractGenerator {

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

		public override string GeneratePersistence(Table table) {
			return "Empty Persistence";
		}
	}
}