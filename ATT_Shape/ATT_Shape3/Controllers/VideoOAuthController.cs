using ATT_Shape.domain.Classes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ATT_Shape3.Controllers
{
    [RoutePrefix("link")]
    public class VideoOAuthController : Controller
    {
        private Dictionary<string, string> QueryParams { get; set; }
        private string client_id { get { return WebConfigurationManager.AppSettings["Client_Id"]; } }
        private string client_secret { get { return WebConfigurationManager.AppSettings["Client_Secret"]; } }
        private string redirect_uri { get { return WebConfigurationManager.AppSettings["Redirect_Uri"]; } }

        [Route("begin")]

        public ActionResult Begin()
        {
            string url = "https://accounts.google.com/o/oauth2/v2/auth?response_type=code&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri) + "&scope=https://www.googleapis.com/auth/youtube.force-ssl" + "&client_id=" + HttpUtility.UrlEncode(client_id) + "&access_type=offline&prompt=consent"; 
            // &prompt=select_account

            return Redirect(url);
        }
        [Route("")]
        public ActionResult Index(string code)
        {
            AssembleBody(client_id, client_secret, redirect_uri, HttpUtility.UrlEncode("authorization_code"), code);

            IRestResponse response = GenericRestSharp("https://www.googleapis.com/oauth2/v4/token", "POST");
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            Dictionary<string, string> data = null;
            data = json_serializer.Deserialize<Dictionary<string,string>>(response.Content.ToString());
            //TODO    insert refresh and access tokens in db
            return Redirect("/");
        }

        private void AssembleBody(string client_id, string client_secret, string redirect_uri, string grant_type, string code)
        {
            if (QueryParams == null)
            {
                QueryParams = new Dictionary<string, string>();
            }
            QueryParams.Add("client_id", client_id);
            QueryParams.Add("client_secret", client_secret);
            QueryParams.Add("redirect_uri", redirect_uri);
            QueryParams.Add("grant_type", grant_type);
            QueryParams.Add("code", code);
        }
        private IRestResponse GenericRestSharp(string url, string method = null, object data = null)
        {
            #region Client

            RestClient rest = null;
            if (url != null)
            {
                rest = new RestClient(url);
            }
            else
            {
                throw new System.Exception("URL is not defined!");
            }

            #endregion


            #region Request

            RestRequest request = new RestRequest();
            switch (method)
            {
                case "GET":
                    request.Method = Method.GET;
                    break;

                case "POST":
                    request.Method = Method.POST;
                    break;

                case "PATCH":
                    request.Method = Method.PATCH;
                    break;

                case "PUT":
                    request.Method = Method.PUT;
                    break;

                case "DELETE":
                    request.Method = Method.DELETE;
                    break;
                default:
                    request.Method = Method.GET;
                    break;
            };
            if(data != null)
            {
                request.AddJsonBody(data);
            }
           
            if (QueryParams != null)
            {
                foreach (var item in QueryParams)
                {
                    request.AddQueryParameter(item.Key, item.Value);
                }
            }
            #endregion


            return rest.Execute(request);


        }
    }
}