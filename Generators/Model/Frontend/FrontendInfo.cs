using Generators.FoldersGenerators.Frontend;
using Utils.Enums.Lenguages;

namespace Generators.Model.Frontend {
	public class FrontendInfo {
		public bool GenerateModel { get; set; }
		public PathsFrontend Paths { get; set; }
		public LenguagesFrontend Lenguaje { get; set; }

		public FrontendInfo(LenguagesFrontend lenguaje, bool generateModel) {
			GenerateModel = generateModel;
			Lenguaje = lenguaje;
		}
	}
}