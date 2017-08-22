using System.Linq;
using System.Web;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.Validators.Enums;

namespace NoteManager.Infrastructure.Http
{
    public static class HttpContextAccess
    {
        public static string GetPublicKey()
        {
            return HttpContext.Current.Request.Headers[GlobalConstants.PublicKey];
        }

        public static Enumerator GetLoginType()
        {
            var headerLoginType = HttpContext.Current.Request.Headers[GlobalConstants.LoginType];
            var loginType = new LoginType().ConvertToCollection().FirstOrDefault(loginTp => loginTp.Value == int.Parse(headerLoginType));
            return loginType;
        }

        public static string CurrentDomain { get; set; }
    }
}