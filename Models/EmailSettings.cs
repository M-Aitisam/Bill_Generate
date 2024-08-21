namespace Bill_Generate.Models
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; } = 465; // Default port for TLS
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
