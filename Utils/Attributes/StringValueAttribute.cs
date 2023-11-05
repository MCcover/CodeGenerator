namespace Utils.Attributes {
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public class StringValueAttribute : CustomAttribute {

		public StringValueAttribute(string value) : base(value) {

		}
	}
}
