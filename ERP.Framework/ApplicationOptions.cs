namespace ERP.Framework
{
    public class ApplicationOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string JwtSecret { get; set; } = null!;                  
        public string NotificationProfileId { get; set; }
        public string NotificationMessageId { get; set; }
        public string NotificationParameterName { get; set; }     
    }
}
