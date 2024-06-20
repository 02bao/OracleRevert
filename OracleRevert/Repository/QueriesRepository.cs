using Microsoft.EntityFrameworkCore;
using OracleRevert.Data;
using OracleRevert.Entity;
using OracleRevert.Interface;

namespace OracleRevert.Repository;

public class QueriesRepository(DataContext _context) : IQueriesRepository
{
    public async Task<bool> InsertData(List<CSB_Revert> Records)
    {
        try
        {
            foreach (var record in Records)
            {
                var ExistId = await _context.Reverts.Where(s => s.Id == record.Id).FirstOrDefaultAsync();

                if (ExistId != null)
                {
                    _context.Entry(ExistId).CurrentValues.SetValues(record);
                }
                else
                {
                    _context.Reverts.Add(record);
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
