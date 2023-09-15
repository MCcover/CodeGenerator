using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators.Interfaces {

	public interface IGenerator {

		void Generate(List<Table> tables);

	}
}