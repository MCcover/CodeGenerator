using Generators.GeneratorsOfCode.Backend;
using Generators.GeneratorsOfCode.Frontend;
using Generators.Interfaces;
using Generators.Model.Backend;
using Generators.Model.Frontend;
using Generators.Model.Generator;
using Utils;

namespace Generators.GeneratorsOfCode {
	public class Generator : SingletonWrapper<Generator>, IGenericGenerator {

		private Generator() {

		}

		public void Generate(GeneratorInfo info) {
			GeneratedBackend backend = null;
			GeneratedFrontend frontend = null;

			if (info.BackendInfo != null) {
				backend = BackendGenerator.Instance.Generate(info.BackendInfo);
			}

			if (info.FrontendInfo != null) {
				frontend = FrontendGenerator.Instance.Generate(info.FrontendInfo);
			}

			throw new NotImplementedException();

		}
	}
}
