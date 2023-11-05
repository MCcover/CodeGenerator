using Utils.Enums.Lenguages;

namespace Utils.Attributes.Class {
	public class LenguageBackendAttribute : CustomAttribute<LenguagesBackend> {
		public LenguageBackendAttribute(LenguagesBackend value) : base(value) {
		}
	}
}
