using System.Data;
using System.Data.Common;

namespace DatabaseConnectors.Persistances.Utils {

	public static class DbCommandExtension {

		public static void AddParameter(this DbCommand cmd, string nameParameter, object value, DbType dbType) {
			var parameter = cmd.CreateParameter();
			parameter.ParameterName = nameParameter;
			parameter.Value = value;
			parameter.DbType = dbType;

			cmd.Parameters.Add(parameter);
		}
	}
}