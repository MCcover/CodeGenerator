using CodeGenerator.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.MethodsOfExtensions {

	public static class StringExtension {

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
	}
}