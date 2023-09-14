using CodeGenerator.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Persistances.Interfaces {

	public interface IPersistance : IDisposable {

		List<Table> GetTables();
	}
}