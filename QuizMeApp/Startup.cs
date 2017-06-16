using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizMeApp.Startup))]
namespace QuizMeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
