using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepo = new OrderDetailRepository();
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderDetail = _orderDetailRepo.GetAll();
            return Ok(orderDetail);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{orderId}/{productId}")]
        public async Task<IActionResult> Get(int orderId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderDetail = _orderDetailRepo.Get(orderId,productId);
            return Ok(orderDetail);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post(BusinessObject.OrderDetails orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            orderDetail.Order = null;
            orderDetail.Product = null;
            _orderDetailRepo.Add(orderDetail);
            return Ok(orderDetail);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> Put(int orderId, int productId, [FromBody] BusinessObject.OrderDetails orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_orderDetailRepo.Get(orderId,productId) == null) return NotFound();
            orderDetail.OrderId = orderId;
            orderDetail.ProductId = productId;
            _orderDetailRepo.Update(orderDetail);
            return Ok(orderDetail);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> Delete(int orderId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_orderDetailRepo.Get(orderId, productId) == null) return NotFound();
            _orderDetailRepo.Delete(orderId, productId);
            return Ok();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _orderDetailRepo.DeleteByOrder(orderId);
            return Ok();
        }
    }
}
