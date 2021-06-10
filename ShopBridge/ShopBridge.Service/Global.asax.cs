using ShopBridge.Business;
using ShopBridge.Service.App_Start;
using ShopBridge.Service.Infrastructure;
using System.Web.Http;

namespace ShopBridge.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterTypes(IocEngine.Container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            EntityMapper.InitializeMapper();
        }
    }
}
