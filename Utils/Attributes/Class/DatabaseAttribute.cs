using Utils.Model.Enums;

namespace Utils.Attributes.Class {
	public class DatabaseAttribute : CustomAttribute<Database> {
		public DatabaseAttribute(Database value) : base(value) {
		}
	}
}
