using CodeGenerator.Model.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.MethodsOfExtensions {

	public static class StringExtension {

		private static Dictionary<Type, string> _TypeMap;
		private static Dictionary<Type, string> TypeMap { 
			get {
				if (_TypeMap == null) {
					_TypeMap = new Dictionary<Type, string>();
					_TypeMap[typeof(byte)] = "DbType.Byte";
					_TypeMap[typeof(sbyte)] = "DbType.SByte";
					_TypeMap[typeof(short)] = "DbType.Int16";
					_TypeMap[typeof(ushort)] = "DbType.UInt16";
					_TypeMap[typeof(int)] = "DbType.Int32";
					_TypeMap[typeof(uint)] = "DbType.UInt32";
					_TypeMap[typeof(long)] = "DbType.Int64";
					_TypeMap[typeof(ulong)] = "DbType.UInt64";
					_TypeMap[typeof(float)] = "DbType.Single";
					_TypeMap[typeof(double)] = "DbType.Double";
					_TypeMap[typeof(decimal)] = "DbType.Decimal";
					_TypeMap[typeof(bool)] = "DbType.Boolean";
					_TypeMap[typeof(string)] = "DbType.String";
					_TypeMap[typeof(char)] = "DbType.StringFixedLength";
					_TypeMap[typeof(Guid)] = "DbType.Guid";
					_TypeMap[typeof(DateTime)] = "DbType.DateTime";
					_TypeMap[typeof(DateTimeOffset)] = "DbType.DateTimeOffset";
					_TypeMap[typeof(byte[])] = "DbType.Binary";
					_TypeMap[typeof(byte?)] = "DbType.Byte";
					_TypeMap[typeof(sbyte?)] = "DbType.SByte";
					_TypeMap[typeof(short?)] = "DbType.Int16";
					_TypeMap[typeof(ushort?)] = "DbType.UInt16";
					_TypeMap[typeof(int?)] = "DbType.Int32";
					_TypeMap[typeof(uint?)] = "DbType.UInt32";
					_TypeMap[typeof(long?)] = "DbType.Int64";
					_TypeMap[typeof(ulong?)] = "DbType.UInt64";
					_TypeMap[typeof(float?)] = "DbType.Single";
					_TypeMap[typeof(double?)] = "DbType.Double";
					_TypeMap[typeof(decimal?)] = "DbType.Decimal";
					_TypeMap[typeof(bool?)] = "DbType.Boolean";
					_TypeMap[typeof(char?)] = "DbType.StringFixedLength";
					_TypeMap[typeof(Guid?)] = "DbType.Guid";
					_TypeMap[typeof(DateTime?)] = "DbType.DateTime";
					_TypeMap[typeof(DateTimeOffset?)] = "DbType.DateTimeOffset";
					_TypeMap[typeof(object)] = "DbType.Object";
					_TypeMap[typeof(DBNull)] = "DbType.Object";
					
				}

				return _TypeMap;
			}
		}

		private static readonly string[] SPECIAL_CHARACTERS = new string[] {
			",", ".", "/", ";", "'",
			"[", "]", "`", "~", "!",
			"@", "#", "$", "%", "^",
			"&", "*", "(", ")", "+",
			"-", "=", "{", "}", "|",
			":", "<", ">", "?", "\"",
			"_", "\\",
		};

		public static string RemoveSpecialCharactersAndFormatText(this string text, char character) {
			string rxString = string.Join("|", SPECIAL_CHARACTERS.Select(Regex.Escape));

			string output = Regex.Replace(text, rxString, character.ToString());
			var parts = output.Split(character);

			var formatedText = "";
			foreach (var part in parts) {
				if (part.Length >= 1) {
					formatedText += part[..1].ToUpper();

					if (part.Length > 1) {
						formatedText += part[1..];
					}
				}
			}

			return formatedText;
		}

		public static string CSharpTypeToDbTypeText(Type type) {
			return TypeMap[type];
		}

	}
}