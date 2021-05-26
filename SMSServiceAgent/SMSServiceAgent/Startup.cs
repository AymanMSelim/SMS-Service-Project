using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMSServiceAgent.Startup))]
namespace SMSServiceAgent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

       
    }
}
