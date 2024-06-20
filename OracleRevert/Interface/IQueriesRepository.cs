using OracleRevert.Entity;

namespace OracleRevert.Interface;

public interface IQueriesRepository
{
    Task<bool> InsertData(List<CSB_Revert> Records);
}
