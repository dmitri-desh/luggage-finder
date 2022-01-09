using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi.Context;

namespace WebApi
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
