using System.Web;
using System.Web.Mvc;

namespace ATT_Shape_Hackathon.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
