using Microsoft.AspNetCore.Http;

namespace ERP.Dtos.Other;

public class UploadInputModel
{
    public IFormFile? File { get; set; } = null;
}
