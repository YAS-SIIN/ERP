namespace ERP.Dtos.Other;

public class ApplicationOptions
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;     
    public double MaximumUploadSizeInBytes { get; set; }

    public string JwtSecret { get; set; } = null!;
    public string JwtKey { get; set; } = null!;
    public string JwtIssuer { get; set; } = null!;
    public string JwtAudience { get; set; } = null!;
    public string JwtSubject { get; set; } = null!;      
}
