using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_GoogleOAuth
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bt.Click += GoogleSignUp;
        }

        private void GoogleSignUp(object sender,EventArgs e)
        {
            var ctx = Request.GetOwinContext();
            ctx.Authentication.Challenge(
                new Microsoft.Owin.Security.AuthenticationProperties
                {
                    RedirectUri=ResolveUrl("~/loginexternal.ashx")
                },
                "Google"
            );

            Response.StatusCode = 401;
            Response.End();
        }
    }
}