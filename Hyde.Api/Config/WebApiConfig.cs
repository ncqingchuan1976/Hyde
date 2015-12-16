using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Hyde.Api.Dispatcher;
using Hyde.Api.Models.RequestCommands;
using Hyde.Api.Services;
using Hyde.Repository;
namespace Hyde.Api.Config
{
    public class WebApiConfig
    {
        public static void WebApiInitial(HttpConfiguration Config)
        {

            Config.ParameterBindingRules.Insert(0, t =>
            typeof(IRequestCommand).IsAssignableFrom(t.ParameterType) ? new FromUriAttribute().GetBinding(t) : null);
        }
    }
}