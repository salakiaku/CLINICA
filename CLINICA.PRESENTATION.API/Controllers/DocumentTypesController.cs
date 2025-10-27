using CLINICA.APPLICATION.DTOS.DocumentTypes.Requests;
using CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA.PRESENTATION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList([FromQuery] int state)
        {

            var response = await _mediator.Send(new GetAllDocumentTypeQuery() { State = state });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] CreateDocumentTypeRequestDTO createDocumentTypeRequestDTO)
        {
            var result = await _mediator.Send(new CreateDocumentTypeCommand() { CreateDocumentTypeRequestDTO = createDocumentTypeRequestDTO });

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateDocumentTypeRequestDTO updateDocumentTypeRequestDTO)
        {

            var response = await _mediator.Send(new UpdateDocumentTypeCommand() { UpdateDocumentTypeRequestDTO = updateDocumentTypeRequestDTO });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("change-state")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateState([FromBody] UpdateDocumentTypeStateRequestDTO  updateDocumentTypeStateRequestDTO)
        {

            var response = await _mediator.Send(new UpdateDocumentTypeStateCommand() { Id =  updateDocumentTypeStateRequestDTO.Id, State = updateDocumentTypeStateRequestDTO.State });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

       
    }
}
