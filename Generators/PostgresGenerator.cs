using CodeGenerator.Generators.Abstracts;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators {

	public class PostgresGenerator : AbstractGenerator {
		public override void Generate(List<Table> tables) {
			foreach (var table in tables) {

				var model = GenerateModel(table);
				var service = GenerateService(table);
				var persistence = GeneratePersistence(table);

				GenerateFolderStructure(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), new GeneratedFileInfo(table, model, service, persistence));
			}
		}

		public override string GeneratePersistence(Table table) {
			return "Empty Persistence";
		}
	}
}