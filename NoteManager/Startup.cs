using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using NoteManager.IoC.Configs;
using NoteManager.Mapper.Configs;
using NoteManager.Sessions;

[assembly: OwinStartup(typeof(NoteManager.Startup))]
namespace NoteManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration(GlobalConfiguration.Configuration.Routes);
            SwaggerConfig.Register(configuration);
            FilterConfig.Register(configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(configuration);
            SimpleInjectorConfig.Register(configuration);
            GlobalConfiguration.Configuration.Filters.Add(new AuthorizeLogin());
            FastMapperConfig.Initialize();
        }
    }
}