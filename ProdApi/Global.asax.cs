﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ProdApi.Models;
using System.Data.Entity;

namespace ProdApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Database.SetInitializer<ProductContext>(new ProductInitializer());
        }
    }
}
