using CLINICA.APPLICATION.DTOS.Specialties.Requests;
using CLINICA.APPLICATION.USECASES.UseCases.Specialties.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Specialties.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.PRESENTATION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecialtiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-list")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll(){

            var response = await _mediator.Send(new GetAllSpecialtyQuery());

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post([FromBody] CreateSpecialtyRequestDTO createSpecialtyRequestDTO)
        {

            var response = await _mediator.Send(new CreateSpecialtyCommand() { CreateSpecialtyRequestDTO = createSpecialtyRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
