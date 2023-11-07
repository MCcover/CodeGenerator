using Domain.Model.Table;

namespace DatabaseConnectors.Persistances.Interfaces {

	public interface IPersistance {

		Task<List<Table>> GetTables();

		Task<List<Column>> GetColumns(string tableName);
	}
}