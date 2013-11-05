using System.Configuration;

namespace DansBlog.Presentation.Config
{
    public class AppSettings : IAppSettings
    {
        #region Archive

        public string ArchiveDisplayCount()
        {
            return ConfigurationManager.AppSettings["Archive_ResultsPage_DisplayCount"];
        }

        #endregion

        #region Search Functionality

        public string SearchPostsToDisplay()
        {
            return ConfigurationManager.AppSettings[""];
        }

        #endregion

        #region Email

        public string SMTP_TargetEmail()
        {
            return ConfigurationManager.AppSettings["Smtp_TargetEmail"];
        }

        public string SMTP_Server()
        {
            return ConfigurationManager.AppSettings["Smtp_Server"];
        }

        #endregion

        #region Quote

        public string XmlQuoteFilePath()
        {
            return ConfigurationManager.AppSettings["Quote_Partial_XmlFilePath"];
        }

        #endregion
    }
}