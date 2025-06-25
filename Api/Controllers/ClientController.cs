using Application.Queries.Client.BirthdayClients;
using Application.Queries.Client.Categories;
using Application.Queries.Client.RecentPurchases;
using Contracts.Client.BirthdayClients;
using Contracts.Client.Categories;
using Contracts.Client.RecentPurchases;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientController(
            IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdayClients([FromQuery] BirthdayClientsRequest request)
        {

            var result = await _mediator.Send(new BirthdayClientsQuery(request.PageNumber, request.PageSize, request.Date));

            var response = _mapper.Map<BirthdayClientsResponse>(result);

            return Ok(response);
        }

        [HttpGet("recent-purchases")]
        public async Task<IActionResult> GetRecentPurchases([FromQuery] RecentPurchasesRequest request)
        {
            var result = await _mediator.Send(new RecentPurchasesQuery(request.PageNumber, request.PageSize, request.Days));

            var response = _mapper.Map<RecentPurchasesResponse>(result);

            return Ok(response);
        }

        [HttpGet("{clientId}/categories")]
        public async Task<IActionResult> GetCategories([FromQuery] ClientCategoriesRequest request, int clientId)
        {
            var result = await _mediator.Send(new ClientCategoriesQuery(request.PageNumber, request.PageSize, clientId));

            var response = _mapper.Map<ClientCategoriesResponse>(result);

            return Ok(response);
        }
    }
}
