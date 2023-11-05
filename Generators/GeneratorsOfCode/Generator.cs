using Generators.Interfaces;
using Generators.Model.Backend;
using Generators.Model.Frontend;
using Generators.Model.Generator;
using System.Reflection;
using Utils;
using Utils.Attributes.Class;

namespace Generators.GeneratorsOfCode {
	public class Generator : SingletonWrapper<Generator>, IGenericGenerator {

		private Generator() {

		}

		public void Generate(GeneratorInfo info) {
			GeneratedBackend backend = null;
			GeneratedFrontend frontend = null;

			if (info.BackendInfo != null) {

				Type? tipoClase = Assembly.GetExecutingAssembly()
										 .GetTypes()
										 .DefaultIfEmpty(null)
										 .FirstOrDefault(t => {
											 var lenguage = t?.GetCustomAttribute<LenguageBackendAttribute>()?.Value == info.BackendInfo.Lenguaje;
											 var database = t?.GetCustomAttribute<DatabaseAttribute>()?.Value == info.BackendInfo.Database;

											 return lenguage && database;
										 });


				if (tipoClase == null) {
					throw new Exception("no generator is defined for this backend language and database.");
				}

				var instance = (IGenerator<GeneratedBackend, BackendInfo>?)Activator.CreateInstance(tipoClase) ?? throw new Exception("");

				backend = instance.Generate(info.BackendInfo);
			}

			if (info.FrontendInfo != null) {
				Type? tipoClase = Assembly.GetExecutingAssembly()
										 .GetTypes()
										 .DefaultIfEmpty(null)
										 .FirstOrDefault(t => {
											 var lenguage = t?.GetCustomAttribute<LenguageFrontendAttribute>()?.Value == info.FrontendInfo.Lenguaje;

											 return lenguage;
										 });


				if (tipoClase == null) {
					throw new Exception("no generator is defined for this frontend language.");
				}

				var instance = (IGenerator<GeneratedFrontend, FrontendInfo>?)Activator.CreateInstance(tipoClase) ?? throw new Exception("");

				frontend = instance.Generate(info.FrontendInfo);

			}

			throw new NotImplementedException();

		}
	}
}
