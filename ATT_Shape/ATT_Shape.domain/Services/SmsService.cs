using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Models.Response;
using ATT_Shape.domain.Services.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ATT_Shape.domain.Services
{
    public class SmsService
    {
        private Dictionary<string, string> Headers { get; set; }
        public SmsService()
        {
            if (Headers == null)
            {
                Headers = new Dictionary<string, string>();
            }
            Headers.Add("authorization", AuthToken);
            Headers.Add("content-type", "application/JSON");
        }
        private string AuthToken { get { return WebConfigurationManager.AppSettings["AttAuthToken"]; } }
        private string Url { get { return WebConfigurationManager.AppSettings["AttIamUrl"]; } }



        public string GetResponse(MessageRequest model, string channelName)
        {
            var msgObj = new
            {
                MessageRequest = new
                {
                    Addresses = model.Addresses
                    , Text = "New content has been added to your channel. Hop on to find out!"
                    , Subject = "Moxie Channel Update - " + channelName
                }
            };


            IRestResponse response = GenericRestSharp(Url, "POST", msgObj);

            return response.Content;
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
                throw new Exception("URL is not defined!");
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

            request.AddJsonBody(data);
            if (Headers != null)
            {
                foreach (var item in Headers)
                {
                    request.AddHeader(item.Key, item.Value);
                }
            }
            #endregion


            return rest.Execute(request);


        }
    }
}
