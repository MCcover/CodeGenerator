﻿using Generators.Enums.Lenguages;
using Utils.Model.Enums;

namespace Generators.Model.Backend {
	public class BackendInfo {

		public string ProjectName { get; set; }

		public bool GenerateModel { get; set; }
		public bool GenerateConstructor { get; set; }
		public bool GenerateService { get; set; }
		public bool GeneratePersistence { get; set; }
		public bool GenerateInterfaces { get; set; }
		public LenguagesBackend Lenguaje { get; set; }
		public Database Database { get; set; }

		public BackendInfo(Database database,
						   LenguagesBackend lenguaje,
						   string projectName,
						   bool generateModel,
						   bool generateConstructor,
						   bool generateService,
						   bool generatePersistence,
						   bool generateInterfaces) {
			GenerateModel = generateModel;
			GenerateConstructor = generateConstructor;
			GenerateService = generateService;
			GeneratePersistence = generatePersistence;
			GenerateInterfaces = generateInterfaces;
			Database = database;
			Lenguaje = lenguaje;
			ProjectName = projectName;
		}
	}
}