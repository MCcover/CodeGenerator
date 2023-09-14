using System.Data.Common;

namespace CodeGenerator.Model.DatabaseConnectors.Interfaces {
	public interface IConnector {
		void Connect(ConnectionInfo info);
		void Disconnect();

		DbConnection GetConnection();

		DbCommand GetCommand();
	}
}
