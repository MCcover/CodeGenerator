using Utils.Enums.Lenguages;

namespace Utils.Attributes.Class {
	public class LenguageFrontendAttribute : CustomAttribute<LenguagesFrontend> {
		public LenguageFrontendAttribute(LenguagesFrontend value) : base(value) {
		}
	}
}
