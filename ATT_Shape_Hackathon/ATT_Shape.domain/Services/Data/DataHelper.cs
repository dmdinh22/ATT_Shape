using System;
using System.Data;
using Microsoft.AspNet.Identity;
using context = System.Web.HttpContext;

namespace ATT_Shape.domain.Services.Data
{
    public static class DataHelper
    {
        public static double GetDouble(this DataRow dr, string column_name)
        {
            double dbl = 0;
            double.TryParse(dr[column_name].ToString(), out dbl);
            return dbl;
        }
        public static double GetDouble(this DataRow dr, int column_index)
        {
            double dbl = 0;
            double.TryParse(dr[column_index].ToString(), out dbl);
            return dbl;
        }
        public static double GetDouble(this IDataReader dr, string column_name)
        {
            double dbl = 0;
            double.TryParse(dr[column_name].ToString(), out dbl);
            return dbl;
        }
        public static double GetDouble(this IDataReader dr, int column_index)
        {
            double dbl = 0;
            double.TryParse(dr[column_index].ToString(), out dbl);
            return dbl;
        }
        public static string GetApiUrl()
        {
            string apiUrl = String.Empty;
            if (context.Current.Request.Url != null)
            {
                apiUrl = context.Current.Request.Url.ToString();
            }
            return apiUrl;
        }
        public static string GetViewUrl()
        {
            string viewUrl = String.Empty;
            if (context.Current.Request.UrlReferrer != null)
            {
                viewUrl = context.Current.Request.UrlReferrer.ToString();
            }
            return viewUrl;
        }
        public static string GetUserId()
        {
            string userId = context.Current.User.Identity.GetUserId();
            
            return userId;
        }
        public static string GetBody()
        {
            string body = String.Empty;
            if (context.Current.Request.Form.Count > 0)
            {
                body = context.Current.Request.Form.ToString();
            }
            if (context.Current.Request.HttpMethod != null)
            {
                body += " (Method: " + context.Current.Request.HttpMethod + ")";
            }
            return body;
        }
    }
}
