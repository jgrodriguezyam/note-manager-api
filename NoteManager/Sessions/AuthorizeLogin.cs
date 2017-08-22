using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Infrastructure.Objects;
using NoteManager.IoC.Configs;

namespace NoteManager.Sessions
{
    public class AuthorizeLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var dataBaseSqlServerOrmLite = SimpleInjectorModule.GetContainer().GetInstance<IDataBaseSqlServerEntityFramework>();
            if (actionExecutedContext.Exception.IsNull() && actionExecutedContext.Response.IsSuccessStatusCode)
            {
                dataBaseSqlServerOrmLite.Commit();
            }
            else
            {
                dataBaseSqlServerOrmLite.Rollback();
            }
        }
    }
}