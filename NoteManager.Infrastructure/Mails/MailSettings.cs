using System.Configuration;
using System.Web;

namespace NoteManager.Infrastructure.Mails
{
    public static class MailSettings
    {
        public static string UserName = ConfigurationManager.AppSettings["UserName"];

        public static string Password = ConfigurationManager.AppSettings["Password"];

        public static string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];

        public static string Port = ConfigurationManager.AppSettings["Port"];

        public static string CreateUri(string validationCode)
        {
            var uriSite = ConfigurationManager.AppSettings["SiteDomain"] + ConfigurationManager.AppSettings["RouteMail"];
            var uri = string.Format("{0}{1}", uriSite, HttpContext.Current.Server.UrlEncode(validationCode));
            return uri;
        }

        public static string CreateUriSite()
        {
            var uriSite = ConfigurationManager.AppSettings["SiteDomain"];
            var uri = string.Format("{0}", uriSite);
            return uri;
        }

        #region Mensajes de Correo

        #region Correo de Activación de la cuenta

        /// <summary>
        /// Mensaje para informar al cliente que se ha registrado y se pide que confime el registro siguiendo una liga que envia por correo
        /// </summary>
        /// <param name="customerName">Nombre del cliente</param>
        /// <param name="customerMiddleName">segundo nombre del cliente</param>
        /// <param name="customerLastName">Apellido del cliente</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageConfirm(string customerName, string customerMiddleName, string customerLastName)
        {
            var message = "<p>Hola " + customerName + " " + customerMiddleName + " " + customerLastName + "</p>"
                + "<p> Muchas gracias por registrarte en LOMSY. Para poder finalizar el registro es necesario que verifiques tu cuenta haciendo click en el botón \"VERIFICAR\". </p>"
                + "<p> Gracias por confiar en nosotros. </p>";
            return message;
        }

        #endregion

        #region Correo Restablecer contraseña 

        /// <summary>
        /// Mensaje donde se informa al cliente que ha solictado una restauración de su contraseña y se envia una contraseña generada
        /// por el sistema y que podra ser cambiada por el cliente al acceder a su cuenta
        /// </summary>
        /// <param name="customerName">Nombre del cliente</param>
        /// <param name="password">Contraseña temporal generada por el sistema</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageRestorePassword(string customerName, string password)
        {
            var message = " <p> Hola " + customerName + " </p>"
                           + "<p>Hemos recibido una solicitud para restaurar tu contraseña.</p>"
                           + "<p>Tu contraseña temporal es: " + password + "</p>"
                           + "<p>Por favor, accedes de nuevo a LOMSY con tu contraseña temporal y modifícala desde tu área de usuario.</p>";
            return message;
        }

        #endregion

        #region Correo de finalización de la encuesta

        /// <summary>
        /// Mensaje que informa al cliente que su registro en el sistema ha sido completado con exito
        /// </summary>
        /// <param name="customerName">Nombre del cliente</param>
        /// <param name="customerMiddleName">segundo nombre del cliente</param>
        /// <param name="customerLastName">Apellido del cliente</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageFinalizeRegistration(string customerName, string customerMiddleName, string customerLastName)
        {
            var message = customerName + " " + customerMiddleName + " " + customerLastName + " Su registro se ha finalizado con exito";
            return message;
        }

        #endregion

        #region Correo de recomendación

        /// <summary>
        /// Mensaje de recomendación para recomendar amigos. 
        /// </summary>
        /// <param name="TofullName">Nombre completo del que invita</param>
        /// <param name="FromfullName">Nombre completo de la persona que es invitada</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageInvitation(string TofullName, string FromfullName)
        {
            var message = "<p> Hola " + TofullName + "</p>"
                + "<p> Tu amigo " + FromfullName + " quiere invitarte a formar parte de LOMSY y disfrutar de un préstamo de 1.300$ en las mejores condiciones.</p>"
                + "<p> Cómo has sido invitado por un amigo que ya tiene un historial de crédito con LOMSY, ahora <b>disfrutas de unas condiciones únicas</b> para solicitar tu primer préstamo. </p>"
                + "<p> Haz click en \"ACEPTAR INVITACIÓN\" para registrarte y solicitar tu primer crédito avalado por "+FromfullName+". </p>";
            return message;
        }

        #endregion

        #region

        /// <summary>
        /// Mensaje de recomendación para recomendar amigos. 
        /// </summary>
        /// <param name="TofullName">Nombre completo del que invita</param>
        /// <param name="FromfullName">Nombre completo de la persona que es invitada</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageInvitationAdministrator(string TofullName, string tasa)
        {
            var message = "<p> Hola " + TofullName + "</p>"
                + "<p> El equipo Lomsy quiere invitarte a formar parte de LOMSY y disfrutar de un préstamo de 1.300$ con una tasa preferencial del "+tasa+"%"
                +" en las mejores condiciones.</p>"
                + "<p> Haz click en \"ACEPTAR INVITACIÓN\" para registrarte y solicitar tu primer crédito.</p>";
            return message;
        }

        #endregion

        #region Correo Cambio de Status

        /// <summary>
        /// Mensaje que informa sobre el Status de la solicitud. Solo se aplica cuando el estatus cambia a Revisión, Aceptado o Rechazado
        /// </summary>
        /// <param name="fullName">Nombre completo de la persona a la que se la a informar</param>
        /// <param name="status">Status de la solicitud</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageInformationStatusSolicitude(string fullName, string status)
        {
            var message = "Estimado " + fullName;
            switch (status)
            {
                case "InReview":
                    message += "<br/>Su solicitud esta siendo REVISADA por un asesor. En breve le informarán sobre el estatus de su solicitud.";
                    break;
                case "Rejected":
                    message += "<br/>Lamentamos informarte que lamentablemente, tu préstamos ha sido rechazado. No te preocupes. Puedes volverlo a intentar de nuevo desde nuestra página web o ponerte en contacto con nosotros.";
                    break;
                case "Accepted":
                    message += "<br/>No alegra informarte que tu solicitud de crédito ha sido aprobada. Tu panel de control se ha actualizado con los detalles del préstamo.";
                    message += "En los próximos minutos recibirás el importe total en tu cuenta bancaria. Dependiendo de tu banco, el importe podría demorarse hasta un máximo de tres días.";
                    break;
            }
            return message;
        }

        #endregion

        #region  Correo recordatorio para terminar el proceso

        /// <summary>
        /// Mensaje que recuerda al cliente que su registro no se completado
        /// </summary>
        /// <param name="fullName">Nombre completo del cliente</param>
        /// <returns>Regresa un string que contiene el cuerpo del mensaje que será enviado</returns>
        public static string CreateMessageNoticeCompleteSurvey(string fullName)
        {
            var message = "<p> Hola " + fullName + "</p>"
               + "<p> Estás a un click de pedir tu primer préstamo en LOMSY, pero necesitamos que completes tu registro. </p>"
               + "Puedes hacerlo ahora haciendo click en \"TERMINAR CUESTIONARIO\".";
            return message;
        }

        #endregion


        #region

        /// <summary>
        /// Crea el pie del mensaje de correo que se va a enviar
        /// </summary>
        /// <returns></returns>
        public static string CreateFooterMessage()
        {
            var message = "<p> Un saludo. </p>"
                +"<p> El equipo LOMSY </p>";

            return message;
        }

        #endregion

        #endregion
    }
}