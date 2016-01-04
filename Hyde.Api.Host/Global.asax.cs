using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Hyde.Api.Config;
using System.Web.Http;
namespace Hyde.Api.Host
{
    public class Global : System.Web.HttpApplication
    {

        public override void Init()
        {           
            PostAuthenticateRequest += (s, e) => { HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required); };
            base.Init();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            RouteConfig.RouteRegister(config);

            AutofacConfig.AutofacRegsiter(config);

            AutoMapperConfig.InitialAutoMapper();

            WebApiConfig.WebApiInitial(config);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}