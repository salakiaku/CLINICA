using CLINICA.APPLICATION.DTOS.Patients.Requests;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.PRESENTATION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-list")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());

            if (!response.IsSuccess)
              return  NotFound(response);

            return Ok(response);
        }
        [HttpGet("get-by-id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetByIdPatientQuery() { Id = id });

            if(!response.IsSuccess)
                NotFound(response);

            return Ok(response);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post([FromBody] CreatePatientRequestDTO createPatientRequestDTO)
        {
            var response = await _mediator.Send(new CreatePatientCommand() { CreatePatientRequestDTO = createPatientRequestDTO });

            if(!response.IsSuccess)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Put([FromBody] UpdatePatientRequestDTO updatePatientRequestDTO)
        {
            var response = await _mediator.Send(new UpdatePatientRequestCommand() { UpdatePatientRequestDTO = updatePatientRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeletePatientRequetCommand() { Id = id });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update-state")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateState([FromBody] UpdatePatientStateRequestDTO updatePatientStateRequestDTO)
        {
            var response = await _mediator.Send(new UpdatePatientStateCommand() { Id = updatePatientStateRequestDTO.Id, State = updatePatientStateRequestDTO.State });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
                    
        }

    }
}
