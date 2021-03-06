﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApp_GoogleOAuth
{
    /// <summary>
    /// Summary description for checklogin
    /// </summary>
    public class checklogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var ctx = context.GetOwinContext();
            var result = ctx.Authentication.AuthenticateAsync("ExternalCookie").Result;
            ctx.Authentication.SignOut("ExternalCookie");
            var id = new ClaimsIdentity(result.Identity.Claims, "MyApp");
            ctx.Authentication.SignIn(id);
            context.Response.Redirect("~/loginuser.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}