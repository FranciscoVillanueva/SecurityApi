using System.Linq;
using System;
using System.Web.Http;
using Security.Models;
using System.Data.Entity.Core.Objects;

namespace Security.Controllers
{
    public class SessionsController : ApiController
    {
        SecurityApiEntities db = new SecurityApiEntities();
        protected static string Key = "1234";
        // ---------------------------------------------------------
        [HttpPost]
        [Route("api/Sessions/Login")]
        public UserLogged Login(User user)
        {
            try
            {
                EndUser UserReg = db.EndUser.Where(x => x.UserName.ToUpper() == user.UserName.ToUpper()).FirstOrDefault();
                string passDb = db.DesencriptaVer2(Key, UserReg.Password).First();
                bool isLogged = db.EndUser.Any(x => x.UserName.ToUpper() == user.UserName.ToUpper() && 
                    passDb == user.Password);
                return new UserLogged() { IsLogged = isLogged, UserName = user.UserName.ToUpper(), Role = UserReg.UserTypeCd };
            }
            catch (Exception e)
            {
                return new UserLogged() { IsLogged = false, UserName = "Not registered", Role = "Not registered" };
                throw e;
            }


            //EndUser UserReg = db.EndUser.Where(x => x.UserName == user.UserName).FirstOrDefault();
            //bool isLogged = false;
            //if (UserReg != null)
            //{
            //    string passbd = db.DesencriptaVer2(Key, UserReg.Password).First();
            //    isLogged = user.Password == passbd;
            //    return new UserLogged() { IsLogged = isLogged, UserName = user.UserName, Role = UserReg.UserTypeCd };
            //}
            //else
            //{
            //    return new UserLogged() { IsLogged = isLogged, UserName = "Not registered", Role = "Not registered" };
            //}
        }
    }
}
