using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;

[assembly: OwinStartup(typeof(WebApp_GoogleOAuth.Startup1))]

namespace WebApp_GoogleOAuth
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(
                new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
                {
                    AuthenticationType = "MyApp",
                    LoginPath = new PathString("/login.aspx")
                });
            //configurar cookies externos
            app.Properties["Microsoft.Owin.Security.Constants.DefaultSignInAsAuthenticationType"] = "ExternalCookie";

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ExternalCookie",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive,
            });

            var googleOAuth2AuthenticationOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "26102073397-1mn26vc7t9h1vecat9vqo17fq0hqooag.apps.googleusercontent.com",
                ClientSecret = "YTpcrArVEAbS6KMT4zv94KkC",

            };

            app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
        }
    }
}
