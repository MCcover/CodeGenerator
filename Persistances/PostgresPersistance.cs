using CodeGenerator.Model.DatabaseConnectors.Connectors;
using CodeGenerator.Model.Table;
using CodeGenerator.Persistances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Persistances {

	public class PostgresPersistance : IPersistance {
		private static volatile object _lock = new object();

		private static PostgresPersistance? _instance;

		public static PostgresPersistance Instance {
			get {
				if (_instance == null) {
					lock (_lock) {
						if (_instance == null) {
							_instance = new PostgresPersistance();
						}
					}
				}
				return _instance;
			}
		}

		private PostgresPersistance() {
		}

		public void Dispose() => _instance = null;

		public List<Table> GetTables() {
			throw new NotImplementedException();
		}
	}
}