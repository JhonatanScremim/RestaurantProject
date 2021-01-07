using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Interfaces;

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
    }
}
