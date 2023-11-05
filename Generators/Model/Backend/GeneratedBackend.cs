namespace Generators.Model.Backend {
	public class GeneratedBackend {
		public string Model { get; set; }
		public string ModelPk { get; set; }
		public string Constructor { get; set; }
		public string Service { get; set; }
		public string Persistence { get; set; }
		public string InterfaceRepository { get; set; }
		public string InterfaceService { get; set; }

		public GeneratedInterfaces Interfaces { get; set; }

		public GeneratedBackend(string model, string modelPk, string constructor, string service, string persistence, string interfaceRepository, string interfaceService, GeneratedInterfaces interfaces) {
			Model = model;
			ModelPk = modelPk;
			Constructor = constructor;
			Service = service;
			Persistence = persistence;
			InterfaceRepository = interfaceRepository;
			InterfaceService = interfaceService;
			Interfaces = interfaces;
		}
	}
}
