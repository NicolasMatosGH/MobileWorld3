using Microsoft.AspNetCore.Mvc;
using MobileWorld.Application.Interfaces;
using MobileWorld.Application.ViewModel;

namespace MobileWorld.API.Controllers
{
    [ApiController]
    [Route("api/v1/Voucher")]
    public class VoucherController : Controller
    {
        private readonly IVoucherAppService _voucherAppService;

        public VoucherController(IVoucherAppService voucherAppService)
        {
            _voucherAppService = voucherAppService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _voucherAppService.SearchAsync(a => true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherViewModel>> Get(Guid id)
        {
            var result = await _voucherAppService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] VoucherViewModel model)
        {
            var result = await _voucherAppService.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] VoucherViewModel model)
        {
            return Ok(_voucherAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _voucherAppService.Remove(id);
            return Ok();
        }
    }
}
