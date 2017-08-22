using System.Web;

namespace NoteManager.Handlers
{
    public class HelpPageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect("swagger/ui/index");
        }

        public bool IsReusable { get { return true; } }
    }
}