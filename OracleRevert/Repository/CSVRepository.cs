using CsvHelper.Configuration;
using CsvHelper;
using OracleRevert.Data;
using OracleRevert.Entity;
using System.Globalization;
using System.Net;

namespace OracleRevert.Repository;

public class CSVRepository(DataContext _context,
    CloudinaryRepository _cloudinary)
{
    public List<CSB_Revert> ReadCsvFile(List<IFormFile> file)
    {
            var fileUrl = _cloudinary.UploadFile(file[0]);
        if (string.IsNullOrEmpty(fileUrl))
        {
            throw new Exception("File upload failed.");
        }

        List<CSB_Revert> records = new List<CSB_Revert>();
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using (var client = new WebClient())
        using (var stream = client.OpenRead(fileUrl))
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, config))
        {
            records = csv.GetRecords<CSB_Revert>().ToList();
        }

        return records;
    }
}
