using System.Data.Common;

namespace CodeGenerator.DatabaseConnectors.Interfaces
{
    public interface IConnectorBase
    {
        void Connect();

        void Disconnect();

        DbConnection GetConnection();

        DbCommand GetCommand();
    }
}
