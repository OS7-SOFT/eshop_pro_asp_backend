using AutoMapper;
using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Intrefaces;
using MediatR;
using EShopPro.Domain.Entities;

namespace EShopPro.Application.Features.Categories.Commands
{
    public record CreateCategoryCommand : IRequest<CategoryCreateDto>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryCreateDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryCreateDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.Name,
                Description = request.Description,
            };
            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CategoryCreateDto>(category);
        }
    }
}
