using Dbops.Application.Commands.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dbops.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        [Route("/query/create")]
        public Task<QuerySubmitResponse> Create(QuerySubmitRequest request)
        {
            return _mediator.Send(request);
        }

        
    }
}
