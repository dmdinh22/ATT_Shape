using System.Data.SqlClient;
using WikiDataProvider.Data.Interfaces;

namespace ATT_Shape_Hackathon.web.Services
{
    public class BaseService
    {
        //Idao to be used in ADO.NET wrapper for Web Services
        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }

        //SqlConnection to be used in ADO.NET wrapper for Web Services
        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}