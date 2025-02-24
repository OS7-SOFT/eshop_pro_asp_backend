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
        public async Task<IActionResult> GetCategories([FromQuery] GetAllCategoriesQuery query)
        {
            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Success)
                return CreatedAtAction(nameof(GetCategories), response);

            return BadRequest(response);
        }
    }
}
