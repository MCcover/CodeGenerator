using System.Reflection;
using Utils.Attributes;

namespace Utils {

	public class ValueEnum<TData> {
		public string Name { get; set; }
		public TData Value { get; set; }
	}

	public static class EnumHelper {

		public static List<ValueEnum<TData>> GetValuesAttributes<TEnum, TData>() {
			var result = new List<ValueEnum<TData>>();

			var enumType = typeof(TEnum);

			foreach (var enumValue in Enum.GetValues(enumType)) {
				string name = Enum.GetName(enumType, enumValue);

				FieldInfo field = enumType.GetField(name);

				var attributes = (CustomAttribute<TData>[])field.GetCustomAttributes(typeof(CustomAttribute<TData>), false);

				if (attributes.Length > 0) {
					TData value = attributes[0].Value;

					result.Add(new ValueEnum<TData> {
						Name = name,
						Value = value
					});
				}
			}

			return result;
		}

		public static List<ValueEnum<string>> GetValuesAttributes<TEnum>() {
			return GetValuesAttributes<TEnum, string>();
		}

		public static List<T> GetAttributeValues<T, TAttribute, TMember>(TMember member) where TAttribute : CustomAttribute<T> {
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

		public static List<string> GetAttributeValues<TMember>(TMember member) {
			return GetAttributeValues<string, CustomAttribute<string>, TMember>(member);
		}

		public static List<string> GetAttributeValues<TAttribute, TMember>(TMember member) where TAttribute : CustomAttribute<string> {
			return GetAttributeValues<string, TAttribute, TMember>(member);
		}

		public static T GetAttributeValue<T, TAttribute, TMember>(TMember member) where TAttribute : CustomAttribute<T> {
			var results = GetAttributeValues<T, TAttribute, TMember>(member);

			var result = default(T);

			if (results.Count > 0) {
				result = results[0];
			}

			return result;
		}

		public static string GetAttributeValue<TMember>(TMember member) {
			return GetAttributeValue<string, CustomAttribute<string>, TMember>(member);
		}

		public static string GetAttributeValue<TAttribute, TMember>(TMember member) where TAttribute : CustomAttribute<string> {
			return GetAttributeValue<string, TAttribute, TMember>(member);
		}
	}
}
