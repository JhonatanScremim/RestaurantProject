using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Interfaces;
using ProjectRestaurant.OutPuts;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/v1/restaurant")]
        public ActionResult PostRestaurant([FromBody] RestaurantInput body)
        {
            var restaurant = _service.PostRestaurant(body);

            if (!restaurant.Validation())
                return BadRequest("Ocorreu um erro");

            return Ok(restaurant);
        }

        [HttpGet]
        [Route("api/v1/restaurant")]
        public async Task<ActionResult> GetAll()
        {
            var listRestaurants = await _service.GetAll();

            var list = listRestaurants.Select(x => new RestaurantOutPut {
                Id = x.RestaurantId,
                Name = x.RestaurantName,
                Kitchen = (int)x.Kitchen,
                City = x.Address.City});

            return Ok(list);
        }
    }
}
