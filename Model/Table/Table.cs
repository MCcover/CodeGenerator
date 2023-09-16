namespace CodeGenerator.Model.Table {

	public class Table {
		public string Name { get; set; }

		public List<Column>? Columns { get; set; } = null;

		public string ClassName { get; set; } = "";

		public Table(string name, string className) {
			Name = name;
			ClassName = className;
		}
	}
}