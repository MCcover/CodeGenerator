namespace Utils.Attributes {
	public static class AttributeExtension {

		public static List<T> GetAttributeValues<T, TAttribute, TMember>(this TMember member) where TAttribute : CustomAttribute<T> {
			var memberInfo = member.GetType().GetMember(member.ToString()).FirstOrDefault();
			var attributes = memberInfo?.GetCustomAttributes(typeof(TAttribute), false).OfType<TAttribute>();

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			if (attributes != null && attributes.Any()) {
				return attributes.Select(attribute => {
					T value = default;
					try {
						value = (T)Convert.ChangeType(attribute.Value, typeof(T));
					} catch (Exception) {
					}

					return value;
				}).ToList();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
			}

			return new List<T>();
		}

		public static List<string> GetAttributeValues<TMember>(this TMember member) {
			return GetAttributeValues<string, CustomAttribute<string>, TMember>(member);
		}

		public static List<string> GetAttributeValues<TAttribute, TMember>(this TMember member) where TAttribute : CustomAttribute<string> {
			return GetAttributeValues<string, TAttribute, TMember>(member);
		}

		public static T GetAttributeValue<T, TAttribute, TMember>(this TMember member) where TAttribute : CustomAttribute<T> {
			var results = GetAttributeValues<T, TAttribute, TMember>(member);

			var result = default(T);

			if (results.Count > 0) {
				result = results[0];
			}

			return result;
		}

		public static string GetAttributeValue<TMember>(this TMember member) {
			return GetAttributeValue<string, CustomAttribute<string>, TMember>(member);
		}

		public static string GetAttributeValue<TAttribute, TMember>(this TMember member) where TAttribute : CustomAttribute<string> {
			return GetAttributeValue<string, TAttribute, TMember>(member);
		}


	}
}
