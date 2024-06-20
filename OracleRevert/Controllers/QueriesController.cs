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
    public async Task<IActionResult> UploadfileCSV([FromForm] List<IFormFile> file)
    {
        var Records =  _csvRepository.ReadCsvFile(file);
        return Ok(Records);
    }

    [HttpPost("InsertData")]
    public async Task<IActionResult> InsertData(List<CSB_Revert> Revert)
    {
        var Record = await _queriesRepository.InsertData(Revert);
        return Ok(Record);
    }
}
