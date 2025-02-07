using EShopPro.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShopPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var products = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(products);
    }
    }
}
