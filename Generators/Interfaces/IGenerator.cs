using CodeGenerator.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generators.Interfaces {

	public interface IGenerator {

		void Generate(List<Table> tables);
	}
}