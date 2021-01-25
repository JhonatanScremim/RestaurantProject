using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Interfaces;
using ProjectRestaurant.OutPuts;
using ProjectRestaurant.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("restaurant/all")]
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


        [HttpGet]
        [Route("restaurant/{id}")]
        public ActionResult GetById(string id)
        {
            var restaurant = _service.GetById(id);

            if (restaurant == null)
                return BadRequest("Ocorreu um erro");

            var model = new RestaurantViewModel
            {
                Id = restaurant.RestaurantId,
                Name = restaurant.RestaurantName,
                Kitchen = (int)restaurant.Kitchen,
                Address = new AddressViewModel
                {
                    Street = restaurant.Address.Street,
                    Number = restaurant.Address.Number,
                    City = restaurant.Address.City,
                    UF = restaurant.Address.UF,
                    Cep = restaurant.Address.Cep
                }
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("restaurant")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var restaurant = _service.GetByName(name);

            if(restaurant == null)
                return BadRequest("Ocorreu um erro");

            var model = restaurant.Select(x => new RestaurantViewModel
            {
                Id = x.RestaurantId,
                Name = x.RestaurantName,
                Kitchen = (int)x.Kitchen,
                Address = new AddressViewModel
                {
                    Street = x.Address.Street,
                    Number = x.Address.Number,
                    City = x.Address.City,
                    UF = x.Address.UF,
                    Cep = x.Address.Cep
                }
            });

            return Ok(model);

        }

        [HttpPost]
        [Route("restaurant")]
        public ActionResult PostRestaurant([FromBody] RestaurantInput body)
        {
            var restaurant = _service.PostRestaurant(body);

            if (!restaurant.Validation())
                return BadRequest("Ocorreu um erro");

            return Ok(restaurant);
        }

        [HttpPut]
        [Route("restaurant")]
        public ActionResult PutRestaurant([FromBody] PutRestaurantInput body)
        {
            var result = _service.PutRestaurant(body);

            if (!result)
                return BadRequest("Nenhum restaurante foi alterado, revise seus parametros");

            return Ok("Restaurante alterado com sucesso !!");
        }

        [HttpPatch]
        [Route("restaurant/{id}")]
        public ActionResult PatchRestaurantKitchen(string id,[FromBody] PutRestaurantInput body)
        {
            var result = _service.UpdateKitchen(id, body.Kitchen);

            if (!result)
                return BadRequest("Não foi possivel alterar o restaurante, revise seus pensamentos");

            return Ok("Restaurante alterado com sucesso !!");
        }
    }
}
