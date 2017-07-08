using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Models.Response;
using ATT_Shape.domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATT_Shape_Hackathon.web.Controllers.API
{
    [RoutePrefix("api/video")]
    public class VideoApiController : ApiController
    {
        [Route, HttpGet] //GET ALL VIDEOS
        public HttpResponseMessage Get()
        {
            BaseResponse r = null;
            HttpStatusCode httpStatus = HttpStatusCode.OK;

            List<ATT_Shape.domain.Classes.Video> videos = VideoService.SelectAll();

            if (videos != null)
            {
                ItemsResponse<ATT_Shape.domain.Classes.Video> vResp = new ItemsResponse<ATT_Shape.domain.Classes.Video>();
                vResp.Items = videos;
                r = vResp;
            }
            else
            {
                r = new ErrorResponse("Bad Request. Data Unavailable.");
                httpStatus = HttpStatusCode.BadRequest;
            }
            return Request.CreateResponse(httpStatus, r);
        }

        [Route("{id:int}"), HttpGet] //GET VIDEO BY ID
        public HttpResponseMessage Get(int id)
        {
            BaseResponse r = null;
            HttpStatusCode httpStatus = HttpStatusCode.OK;

            ItemResponse<ATT_Shape.domain.Classes.Video> vResp = new ItemResponse<ATT_Shape.domain.Classes.Video>();

            vResp.Item = VideoService.Select(id);

            if (vResp.Item != null)
            {
                r = vResp;
            }
            else
            {
                r = new ErrorResponse("Bad Request. Data Unavailable.");
                httpStatus = HttpStatusCode.BadRequest;
            }
            return Request.CreateResponse(httpStatus, r);
        }

        [Route, HttpPost] //POST: api/video
        public HttpResponseMessage Post(VideoAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                ItemResponse<int> resp = new ItemResponse<int>();
                resp.Item = VideoService.Insert(model);

                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }

        }
        
        [Route, HttpPut] // PUT: api/video
        public HttpResponseMessage Update(VideoUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {

                SuccessResponse resp = new SuccessResponse();

                VideoService.Update(model);

                return Request.CreateResponse(HttpStatusCode.OK, resp); 
            }
        }
        
        [Route("{id:int}"), HttpDelete] // DELETE: api/video/5
        public HttpResponseMessage Delete(int id)
        {
            SuccessResponse resp = new SuccessResponse();

            VideoService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}
