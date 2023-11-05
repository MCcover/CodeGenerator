using Domain.Model.Table;

namespace Generators.Interfaces {
	public interface IGenerator<R, G> {

		R Generate(G info, Table tables);
	}
}
