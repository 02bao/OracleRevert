using Microsoft.AspNetCore.Mvc;
using OracleRevert.Data;
using OracleRevert.Entity;
using OracleRevert.Interface;
using OracleRevert.Repository;

namespace OracleRevert.Controllers;

public class QueriesController(
    DataContext _context, 
    IQueriesRepository _queriesRepository,
    CSVRepository _csvRepository) : ControllerBase
{
    [HttpPost("Upload-CSV")]
    public IActionResult UploadfileCSV(IFormFile file)
    {
        List<CSB_Revert> Records = _csvRepository.ReadCsvFile_V2(file);
        return Ok(Records);
    }

    [HttpPost("InsertData")]
    public async Task<IActionResult> InsertData(List<CSB_Revert> Revert)
    {
        var Record = await _queriesRepository.InsertData(Revert);
        return Ok(Record);
    }
}
