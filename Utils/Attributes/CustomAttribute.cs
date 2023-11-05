namespace Utils.Attributes {
	public class CustomAttribute : Attribute {

		public string Value { get; }

		public CustomAttribute(string value) {
			Value = value;
		}
	}
}
