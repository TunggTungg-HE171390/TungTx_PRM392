using AutoMapper.Execution;
using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var member = _memberRepository.GetAll();
            return Ok(member);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var member = _memberRepository.Get(id);
            return Ok(member);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<IActionResult> Post(BusinessObject.Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _memberRepository.Add(member);
            return Ok(member);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BusinessObject.Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_memberRepository.Get(id) == null) return NotFound();
            member.MemberId = id;
            _memberRepository.Update(member);
            return Ok(member);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_memberRepository.Get(id) == null) return NotFound();
            _memberRepository.Delete(id);
            return Ok();
        }
    }
}
