namespace Utils.Attributes.Fields {
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public class StringValueAttribute : CustomAttribute<string> {

		public StringValueAttribute(string value) : base(value) {

		}
	}
}
