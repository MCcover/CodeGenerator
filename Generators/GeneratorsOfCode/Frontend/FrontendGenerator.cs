using Generators.Interfaces;
using Generators.Model.Frontend;
using Utils;

namespace Generators.GeneratorsOfCode.Frontend {
	public class FrontendGenerator : SingletonWrapper<FrontendGenerator>, IGenerator<GeneratedFrontend, FrontendInfo> {

		private FrontendGenerator() {

		}

		public GeneratedFrontend Generate(FrontendInfo info) {
			throw new NotImplementedException();
		}
	}
}
