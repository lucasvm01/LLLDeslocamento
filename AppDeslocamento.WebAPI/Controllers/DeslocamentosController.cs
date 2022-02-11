using AppDeslocamento.Application.Deslocamentos.Commands;
using AppDeslocamento.Application.Deslocamentos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class DeslocamentosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentoQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IniciarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        //[HttpPut("FinalizarDeslocamento/{deslocamentoId:long}")]
        //public async Task<IActionResult> PutFinalizarAsync([FromRoute] long deslocamentoId,
        //                                            [FromBody] FinalizarDeslocamentoCommand command)
        //{
        //    if (deslocamentoId != command.deslocamentoId) return BadRequest();

        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}
    }
}
