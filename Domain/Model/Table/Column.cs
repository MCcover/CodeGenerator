namespace Domain.Model.Table {

	public class Column {
		public string Name { get; set; }
		public string DataType { get; set; }
		public bool InConstructor { get; set; }
		public string PropertyName { get; set; }
		public bool Iskey { get; set; }
		public bool IsNullable { get; set; }

		public Column(string name, string dataType, bool inConstructor, string propertyName, bool iskey, bool isNullable) {
			Name = name;
			DataType = dataType;
			InConstructor = inConstructor;
			PropertyName = propertyName;
			Iskey = iskey;
			IsNullable = isNullable;
		}
	}
}