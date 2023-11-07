namespace Utils.Attributes {
	public class CustomAttribute<T> : Attribute {

		public T Value { get; }

		public CustomAttribute(T value) {
			Value = value;
		}
	}
}
