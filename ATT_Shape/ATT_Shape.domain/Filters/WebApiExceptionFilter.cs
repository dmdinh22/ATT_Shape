using ATT_Shape.domain.Services;
using System.Net;
using System.Web.Http.Filters;

namespace ATT_Shape.domain.Filters
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LoggerService.Insert(actionExecutedContext.Exception);
            actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
