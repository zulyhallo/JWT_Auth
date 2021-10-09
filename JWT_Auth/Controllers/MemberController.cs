using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JWT_Auth.Models;



namespace JWT_Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly List<Member> lstMember = new List<Member>()
        {
            new Member{Id=1, Name="ZEZE" },
            new Member {Id=2, Name="NANA" },
            new Member{Id=3, Name="NİNA"}
        };
        public MemberController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<Member> AllMembers()
        {
            return lstMember;
        }


        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public Member MemberByid(int id)
        {
            return lstMember.Find(x => x.Id == id);
        }

        [AllowAnonymous]
        // POST api/<MemberController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        
      // // PUT api/<MemberController>/5
      // [HttpPut("{id}")]
      // public void Put(int id, [FromBody] string value)
      // {
      // }
      //
      // // DELETE api/<MemberController>/5
      // [HttpDelete("{id}")]
      // public void Delete(int id)
      // {
      // }
    }
}
