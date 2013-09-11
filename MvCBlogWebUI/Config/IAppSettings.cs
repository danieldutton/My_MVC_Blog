namespace DansBlog.Presentation.Config
{
    public interface IAppSettings
    {
        string SMTP_TargetEmail();
        string SMTP_Server();
        string XmlQuoteFilePath();
    }
}