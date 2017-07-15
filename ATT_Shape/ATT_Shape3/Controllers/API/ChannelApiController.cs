using ATT_Shape.domain.Classes;
using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Models.Response;
using ATT_Shape.domain.Services;
using ATT_Shape3.web.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATT_Shape3.web.Controllers.API
{
    [RoutePrefix("api/channel")]
    public class ChannelApiController : ApiController
    {
        [Route("{id:int}"), HttpPost]
        public HttpResponseMessage AddSubscribe(UserChannelRequest channel, int id)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            UserService userSrv = new UserService();
            channel.UserId = userSrv.GetCurrentUserId();
            if(id == 0)
            {
                id = 4;
            }
            channel.ChannelId = id;
            ChannelService svc = new ChannelService();
            svc.Channel_InsertUserId(channel);

            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllChannels()
        {
            ItemsResponse<Channel> response = new ItemsResponse<Channel>();
            try
            {
                ChannelService svc = new ChannelService();
                List<Channel> channels = svc.Channel_SelectAll();
                response.Items = channels;
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }//GetAllChannels

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetChannelById([FromUri] int id)
        {
            ItemResponse<Channel> response = new ItemResponse<Channel>();
            try
            {
                ChannelService svc = new ChannelService();
                Channel channel = svc.Channel_SelectById(id);
                response.Item = channel;
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);

        } //GetChannelById

        [HttpGet]
        [Route("{title}")]
        public HttpResponseMessage GetChannelByTitle([FromUri] string title)
        {
            ItemResponse<Channel> response = new ItemResponse<Channel>();
            try
            {
                ChannelService svc = new ChannelService();
                Channel channel = svc.Channel_SelectByTitle(title);
                response.Item = channel;
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        } //GetChannelByTitle

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateChannel([FromBody] Channel payload)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            ItemResponse<int> response = new ItemResponse<int>();
            try
            {
                ChannelService svc = new ChannelService();
                response.Item = svc.Channel_Insert(payload);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        } //CreateChannel

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateChannel([FromUri] int id, [FromBody] Channel model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);

            try
            {
                ChannelService svc = new ChannelService();
                svc.Channel_UpdateById(model);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        } //UpdateChannel

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteChannelById([FromUri] int id)
        {
            try
            {
                ChannelService svc = new ChannelService();
                svc.Channel_DeleteById(id);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }//DeleteChannelById
    }
}
