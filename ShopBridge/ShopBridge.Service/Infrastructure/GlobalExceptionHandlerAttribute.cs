using Microsoft.Practices.Unity;
using ShopBridge.Business.Contract;
using ShopBridge.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ShopBridge.Service.Infrastructure
{
    public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private IExceptionLoggerManager ExceptionLoggerManager;

        public GlobalExceptionHandlerAttribute()
        {
            ExceptionLoggerManager = IocEngine.Container.Resolve<IExceptionLoggerManager>();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                var exception = new ExceptionLogData()
                {
                    Message = actionExecutedContext.Exception.Message,
                    StackTrace = actionExecutedContext.Exception.StackTrace,
                    CreatedDate = System.DateTime.Now
                };
                
                string refID = ExceptionLoggerManager.Save(exception);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, $"Service error occured.  Please Contact to Service Application Administrator with this reference ID:  {refID}");
            }
            catch (Exception ex)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex.Message);
            }
        }
    }
}
