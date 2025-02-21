using EShopPro.Application.Features.Categories.Commands;
using EShopPro.Application.Features.Categories.Queries;
using EShopPro.Domain.Common;
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
            var categories = await _mediator.Send(new GetAllCategoriesQuery());


            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Success)
                return CreatedAtAction(nameof(GetCategories), new { category = response.Data }, command);

            return BadRequest(response);
        }
    }
}
