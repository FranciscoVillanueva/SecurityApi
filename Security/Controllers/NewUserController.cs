using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Security.Controllers
{
    public class NewUserController : ApiController
    {
        SecurityApiEntities db = new SecurityApiEntities();
        protected static string Key = "1234";
        [HttpPost]
        [Route("api/NewUser/CreateUser")]
        public IHttpActionResult CreateUser(NewUser newUser)
        {
            UserEntity usEnt = new UserEntity()
            {
                UserEntityTypeCd = "USR",
                IsEnabled = true,
                IsDeleted = false,
                LastModDt = DateTime.Now
            };
            db.UserEntity.Add(usEnt);

            EndUser newUserTodb = new EndUser()
            {
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Password = db.EncriptaVer2(Key, newUser.Password).First(),
                DomainId = 1,
                UserEntityId = usEnt.UserEntityId,
                UserTypeCd = "EXT",
                IsEnabled = true,
                IsDeleted = false,
                LastModDt = DateTime.Now,
                ExpirateDate = DateTime.Now
            };
            db.EndUser.Add(newUserTodb);
            db.SaveChanges();

            return Ok();
        }
    }
}
