using HotelAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IHttpActionResult Login([FromUri] string userName, string Password)        
        {
            var LoginResult="";

            HotelBookingTeam4Entities obj = new HotelBookingTeam4Entities();
            userName = userName ?? string.Empty;

            var userResult = obj.tblUsers.Where(user => (user.Name ?? string.Empty).ToUpper() == userName.ToUpper() && user.Password == Password).FirstOrDefault();


            if (userResult != null)
            {
                LoginResult = "success";
            }
            else
            {
                LoginResult = "Fail";
            }
            //return Ok(JsonConvert.SerializeObject(LoginResult));
            return Ok(JsonConvert.SerializeObject( LoginResult));
        }


        [HttpPost]
        public IHttpActionResult Register([FromUri] UserDetails userDetails)
        {
            

            return Ok();
        }



        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
