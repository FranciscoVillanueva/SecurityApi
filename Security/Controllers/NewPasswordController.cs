using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcademyLog;
namespace Security.Controllers
{
    public class NewPasswordController : ApiController
    {
        LogEntity log = new LogEntity();

        SecurityApiEntities db = new SecurityApiEntities();
        protected static string Key = "1234";

        [HttpPost]
        [Route("api/NewPassword/ChangePassword")]
        public bool ChangePassword(ChangePassword user)
        {
            try
            {
                EndUser UserFromBd = db.EndUser.Where(x => x.UserName.ToUpper() == user.UserName.ToUpper()).First();
                byte[] newPass = db.EncriptaVer2(Key, user.NewPassword).First();
                UserFromBd.Password = newPass;
                log.mensaje = "the user " + user.UserName + " changed password";
                log.aplicacion = "security";
                log.fecha = DateTime.Now;
                new Log().ConnectToWebAPI(log);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;      
            }
        }
    }
}
