namespace Utils {
	public static class FileHelper {
		public static void GenerateFile(string path, string text) {
			using (var fs = File.CreateText(path)) {
				fs.Write(text);
			}
		}
	}
}
