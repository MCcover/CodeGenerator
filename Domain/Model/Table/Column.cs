namespace Domain.Model.Table {

	public class Column {
		public string Name { get; set; }
		public string DataType { get; set; }
		public bool InConstructor { get; set; }
		public string PropertyName { get; set; }
		public bool Iskey { get; set; }
		public bool IsNullable { get; set; }

		public Foreign Foreign { get; set; }

		public Column(string name, string dataType, bool inConstructor, string propertyName, bool iskey, bool isNullable, Foreign foreign) {
			Name = name;
			DataType = dataType;
			InConstructor = inConstructor;
			PropertyName = propertyName;
			Iskey = iskey;
			IsNullable = isNullable;
			Foreign = foreign;
		}
	}

	public class Foreign {
		public string Table { get; set; }
		public string Column { get; set; }
		public string ClassName { get; set; }

		public Foreign(string table, string column) {
			Table = table;
			Column = column;
		}

		public override bool Equals(object? obj) {
			if (obj == null) return false;
			if (obj is not Foreign) return false;

			var other = obj as Foreign;

			if (other.Table == null || other.Table == string.Empty) return false;

			if (other.Column == null || other.Column == string.Empty) return false;


			return other.Table == Table && other.Column == Column;
		}

		public override int GetHashCode() {
			return HashCode.Combine(Table, Column);
		}
	}
}