using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Serilog;

namespace OracleRevert.Repository;

public class CloudinaryRepository
{
    private readonly Cloudinary _cloudinary;
    public CloudinaryRepository()
    {
        var CloudinaryAccount = new Account(
            "dbc7m2bfe",
            "414433899294356",
           "Ftv4-eQroBMkGXO9oEmAshTn5M0"
        );
        _cloudinary = new Cloudinary(CloudinaryAccount);
        _cloudinary.Api.Secure = true;
    }

    public string UploadFile(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return "";
            }
            using (var stream = file.OpenReadStream())
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = Guid.NewGuid().ToString(),
                    Folder = "review",
                };
                ImageUploadResult result = _cloudinary.Upload(uploadParams);
                if (result.Error != null)
                {
                    Log.Error(result.Error.ToString());
                    return "";
                }
                return result.SecureUrl.ToString();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        return "";
    }
}
