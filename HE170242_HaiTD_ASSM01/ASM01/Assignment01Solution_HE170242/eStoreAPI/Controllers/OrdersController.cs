using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderrepo = new OrderRepository();
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = _orderrepo.GetAll();
            return Ok(order);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = _orderrepo.Get(id);
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post(BusinessObject.Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.member = null;
            order.OrderDetails = null;
            _orderrepo.Add(order);
            return Ok(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BusinessObject.Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_orderrepo.Get(id) == null) return NotFound();
            order.OrderId = id;
            _orderrepo.Update(order);
            return Ok(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_orderrepo.Get(orderId) == null) return NotFound();
            _orderrepo.Delete(orderId);
            return Ok();
        }

        [HttpDelete("{orderId}/{memberId}")]
        public async Task<IActionResult> Delete(int orderId, int memberId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _orderrepo.DeleteByMember(memberId);
            return Ok();
        }
    }
}
