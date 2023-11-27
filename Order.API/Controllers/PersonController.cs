using Microsoft.AspNetCore.Mvc;
using Person.Application.Services.Interfaces;

namespace Restaurant.Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _personService.GetAll();

            return Ok(response);
        }
    }
}
