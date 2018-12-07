using System.Collections.Generic;
using System.Threading.Tasks;
using ItemFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var items = await _repository.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{x},{y}")]
        public async Task<ActionResult<Task<Item>>> Get(double x, double y)
        {
            if (x > 90 || x < -90)
            {
                return BadRequest("Values are supposed to be between -90 and 90");
            }
            var result = await _repository.FindCloseItem(new ItemLocation
            {
                X = x,
                Y = y
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Item value)
        {
            await _repository.PostNewItem(value);
            return Ok();
        }
    }
}