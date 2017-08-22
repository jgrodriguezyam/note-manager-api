using System.Web.Http;
using Swashbuckle.Application;
using NoteManager.Filters;

namespace NoteManager
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration
                .EnableSwagger(configure =>
                {
                    configure.SingleApiVersion("v1", "NoteManager");
                    configure.OperationFilter<SwaggerOperationFilter>();
                })
                .EnableSwaggerUi();
        }
    }
}