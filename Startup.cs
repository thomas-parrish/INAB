using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using INAB.Providers;
using System.Configuration;
using System.Data.SqlClient;
using Insight.Database;

[assembly: OwinStartup(typeof(INAB.Startup))]

namespace INAB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureDb(app);
            ConfigureOAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider("INAB")
            };
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void ConfigureDb(IAppBuilder app)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            app.CreatePerOwinContext<SqlConnection>(() => new SqlConnection(connectionString));
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}
