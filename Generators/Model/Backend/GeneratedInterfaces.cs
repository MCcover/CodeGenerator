namespace Generators.Model.Backend {
	public class GeneratedInterfaces {
		public string Add { get; set; }
		public string Modify { get; set; }
		public string Delete { get; set; }
		public string List { get; set; }
		public string Exists { get; set; }
		public string ValidateData { get; set; }
		public string Service { get; set; }
		public string Repository { get; set; }
		public string Connection { get; set; }

		public GeneratedInterfaces() {
			Add =
			Modify =
			Delete =
			List =
			Exists =
			ValidateData =
			Service =
			Repository =
			Connection = string.Empty;
		}

		public GeneratedInterfaces(string add,
								   string modify,
								   string delete,
								   string list,
								   string exists,
								   string validateData,
								   string service,
								   string repository,
								   string connection) {
			Add = add;
			Modify = modify;
			Delete = delete;
			List = list;
			Exists = exists;
			ValidateData = validateData;
			Service = service;
			Repository = repository;
			Connection = connection;
		}
	}
}
