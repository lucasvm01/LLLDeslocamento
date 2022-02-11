using AppDeslocamento.Application.Condutores.Commands;
using AppDeslocamento.Application.Condutores.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class CondutoresController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
