namespace CodeGenerator.Model.Table {

	public class Column {
		public string Name { get; set; }
		public string DataType { get; set; }
		public bool InConstructor { get; internal set; }

		public Column(string name, string dataType, bool inConstructor) {
			Name = name;
			DataType = dataType;
			InConstructor = inConstructor;
		}
	}
}