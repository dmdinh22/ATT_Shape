using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Models.Response;
using ATT_Shape.domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ATT_Shape3.Controllers.API
{
    [RoutePrefix("channels/api/sms")]
    public class SmsApiController : ApiController
    {
        [Route("{channelName:minlength(2)}"), HttpPost] //POST: api/sms
        public HttpResponseMessage Post(MessageRequest model, string channelName)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {

                ATT_Shape.domain.Services.SmsService svc = new ATT_Shape.domain.Services.SmsService();
                string msgId = svc.GetResponse(model, channelName);

                ItemResponse<string> resp = new ItemResponse<string>();
                resp.Item = msgId;

                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }

        }
    }
}
