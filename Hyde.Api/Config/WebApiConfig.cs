using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Hyde.Api.Dispatcher;
namespace Hyde.Api.Config
{
    public class WebApiConfig
    {
        public static void WebApiInitial(HttpConfiguration Config)
        {
            Config.MessageHandlers.Add(new SupplyDispatcher());
        }
    }
}