namespace CodeGenerator.Model.Table {

	public class Column {
		public string Name { get; set; }
		public string DataType { get; set; }
		public bool InConstructor { get; internal set; }
		public string PropertyName { get; set; }

		public Column(string name, string dataType, bool inConstructor, string propertyName) {
			Name = name;
			DataType = dataType;
			InConstructor = inConstructor;
			PropertyName = propertyName;
		}
	}
}