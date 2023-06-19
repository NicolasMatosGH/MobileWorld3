using MobileWorld.Application.Interfaces;
using MobileWorld.Application.Services;
using MobileWorld.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Application.Interfaces;
using MobileWorld.Application.ViewModel;

namespace DevGames.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/orderItem")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemAppService _orderItemAppService;

        public OrderItemController(IOrderItemAppService orderItemAppService)
        {
            _orderItemAppService = orderItemAppService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok((await _orderItemAppService.SearchAsync(a => true)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemViewModel>> Get(Guid id)
        {
            return Ok(await _orderItemAppService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] OrderItemViewModel model)
        {
            return Ok(await _orderItemAppService.AddAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] OrderItemViewModel model)
        {
            return Ok(_orderItemAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _orderItemAppService.Remove(id);
            return Ok();
        }
    }
}
