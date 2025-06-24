using Application.Queries.Client.BirthdayClients;
using Application.Queries.Client.Categories;
using Application.Queries.Client.RecentPurchases;
using Contracts.Client.BirthdayClients;
using Contracts.Client.Categories;
using Contracts.Client.RecentPurchases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly IMediator _mediator;

        public ClientController(
            ILogger<ClientController> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdayClients([FromQuery] BirthdayClientsRequest request)
        {

            var result = await _mediator.Send(new BirthdayClientsQuery(request.PageNumber, request.PageSize, request.Date));
            return Ok(result);
        }

        [HttpGet("recent-purchases")]
        public async Task<IActionResult> GetRecentPurchases([FromQuery] RecentPurchasesRequest request)
        {
            var result = await _mediator.Send(new RecentPurchasesQuery(request.PageNumber, request.PageSize, request.Days));
            return Ok(result);
        }

        [HttpGet("{clientId}/categories")]
        public async Task<IActionResult> GetCategories([FromQuery] CategoriesRequest request, int clientId)
        {
            var result = await _mediator.Send(new ClientCategoriesQuery(request.PageNumber, request.PageSize, clientId));
            return Ok(result);
        }
    }
}
