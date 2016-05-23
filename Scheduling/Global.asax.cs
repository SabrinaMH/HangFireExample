using System.Web;
using System.Web.Http;
using Hangfire;

namespace Scheduling
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("dbConnection");

            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
