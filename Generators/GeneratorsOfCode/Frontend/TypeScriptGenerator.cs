using Domain.Model.Table;
using Generators.Interfaces;
using Generators.Model.Frontend;
using Utils.Attributes.Class;
using Utils.Enums.Lenguages;

namespace Generators.GeneratorsOfCode.Frontend {

	[LenguageFrontend(LenguagesFrontend.TypeScript)]
	public class TypeScriptGenerator : IFrontendGenerator {
		public GeneratedFrontend Generate(FrontendInfo info, Table table) {
			var model = string.Empty;

			if (info.GenerateModel) {
				model = GenerateModelFrontend(table);
			}


			return new GeneratedFrontend(model);
		}

		public string GenerateModelFrontend(Table table) {
			var text = "class {{className}} {" + Environment.NewLine;

			foreach (var column in table.Columns) {
				text += $"\t{column.PropertyName} : {ConvertTypeBdToTypeScript(column.DataType)}; " + Environment.NewLine + Environment.NewLine;
			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string ConvertTypeBdToTypeScript(string typeBd) {
			var typeScriptType = "";

			switch (typeBd) {
				case "bit":
				case "bool":
					typeScriptType = "boolean";
					break;

				case "bytea":
					typeScriptType = "Uint8Array";
					break;

				case "date":
				case "timestamp":
				case "timetz":
				case "timestamptz":
					typeScriptType = "Date";
					break;

				case "numeric":
				case "money":
				case "float8":
				case "float4":
				case "int4":
				case "int8":
				case "int2":
					typeScriptType = "number";
					break;

				case "uuid":
				case "bpchar":
				case "json":
				case "text":
				case "varchar":
					typeScriptType = "string";
					break;

				case "interval":
				case "time":
					typeScriptType = "string"; // Ajusta según tus preferencias para representar intervalos de tiempo en TypeScript.
					break;
			}

			return typeScriptType;
		}

	}
}
