using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authentication_session_.Startup))]
namespace Authentication_session_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
