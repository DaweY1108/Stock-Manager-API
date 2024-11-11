using Microsoft.AspNetCore.Mvc;
using Stock_Manager_API.Models;
using Stock_Manager_API.Services;

namespace Stock_Manager_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService service) =>
            _stockService = service;

        [HttpGet]
        public async Task<List<Stock>> Get() =>
            await _stockService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Stock>> Get(string id)
        {
            var stock = await _stockService.GetAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> Create(Stock newStock)
        {
            await _stockService.CreateAsync(newStock);

            return CreatedAtAction(nameof(Get), new { id = newStock.Id }, newStock);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Stock updatedStock)
        {
            var stock = await _stockService.GetAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            await _stockService.UpdateAsync(id, updatedStock);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var stock = await _stockService.GetAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            await _stockService.RemoveAsync(id);

            return NoContent();
        }

    }
}
