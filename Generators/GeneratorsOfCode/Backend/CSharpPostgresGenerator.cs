using Generators.Interfaces;
using Generators.Model.Backend;
using Utils.Attributes.Class;
using Utils.Enums.Lenguages;
using Utils.Model.Enums;

namespace Generators.GeneratorsOfCode.Backend {
	[LenguageBackend(LenguagesBackend.CSharp)]
	[Database(Database.Postgres)]
	public class CSharpPostgresGenerator : IGenerator<GeneratedBackend, BackendInfo> {

		public GeneratedBackend Generate(BackendInfo info) {
			throw new NotImplementedException();
		}

	}
}
