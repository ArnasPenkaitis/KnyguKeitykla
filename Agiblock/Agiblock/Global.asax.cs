using Agiblock.Repository.Interface;
using System.Web;
using System.Web.Http;

namespace Agiblock
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

    }
}
