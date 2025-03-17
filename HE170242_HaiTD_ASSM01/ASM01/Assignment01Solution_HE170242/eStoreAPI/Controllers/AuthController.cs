using BusinessObject;
using DataAccess.Repository;
using eStoreAPI.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var member = _memberRepository.auth(request.email, request.password);
            return Ok(member);
            
        }
    }
}
