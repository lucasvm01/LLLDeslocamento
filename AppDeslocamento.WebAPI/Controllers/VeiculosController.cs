using AppDeslocamento.Application.Veiculos.Commands;
using AppDeslocamento.Application.Veiculos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class VeiculosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetVeiculosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarVeiculoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
