using System.Data.Common;
using CodeGenerator.Model;

namespace CodeGenerator.DatabaseConnectors.Interfaces {

	public interface IConnector {

		void Connect(ConnectionInfo info);

		void Disconnect();

		DbConnection GetConnection();

		DbCommand GetCommand();
	}
}