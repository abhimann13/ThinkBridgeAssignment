using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Service.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "Welcome to ShopBridge";
        }
    }
}
