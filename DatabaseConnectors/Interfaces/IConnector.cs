using Domain.Model;
using System.Data.Common;

namespace DatabaseConnectors.Interfaces {

	public interface IConnector {

		void Connect(ConnectionInfo info);

		void Disconnect();

		DbConnection GetConnection();

		DbCommand GetCommand();
	}
}