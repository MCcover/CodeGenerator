namespace Utils {
	public static class FolderHelper {
		public static void GenerateDirectory(string destinationPath, string directoryName) {
			var path = Path.Combine(destinationPath, directoryName);
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}
	}
}
