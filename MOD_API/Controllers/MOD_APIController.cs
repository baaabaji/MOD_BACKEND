using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MOD_DATA;
using MOD_BLO;


namespace MOD_API.Controllers
{
    public class MOD_APIController : ApiController
    {

        MOD_BLO.ULogic UL = new MOD_BLO.ULogic();


        [Route("api/GetAllUser")]
        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            var resut= UL.GetAllUsers();
            return Ok(resut);
        }
        [Route("api/getuserbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var result = UL.GetUserById(id);
            return Ok(result);
        }

        [Route("api/blockuser/{id}")]
        [HttpGet]
        public IHttpActionResult BlockUser(int id)
        {
            UL.BlockUser(id);
            return Ok("User Blocked");

        }

        [Route("api/unblockuser/{id}")]
        [HttpGet]
        public IHttpActionResult UnblockUser(int id)
        {
            UL.UnBlockUser(id);
            return Ok("User Unblocked");
        }

    

        [Route("api/login")]
        [HttpGet]
        public IHttpActionResult loginData(string email, string password)
        {
            usign result = UL.login(email, password);
            return Ok(result);
        }


        [Route("api/register")]
        [HttpPost]
        public IHttpActionResult Register(usign User)
        {
            UL.Register(User);
            return Ok("User Added");
        }
    }
}
