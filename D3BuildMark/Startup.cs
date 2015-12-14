using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(D3BuildMark.Startup))]
namespace D3BuildMark
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
