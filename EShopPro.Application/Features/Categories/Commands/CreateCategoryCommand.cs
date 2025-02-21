using AutoMapper;
using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Intrefaces;
using MediatR;
using EShopPro.Domain.Entities;
using EShopPro.Domain.Common;

namespace EShopPro.Application.Features.Categories.Commands
{
    public record CreateCategoryCommand (string Name,string Description) : IRequest<ApiResponse<CategoryCreateDto>>;
    

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryCreateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryCreateDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTimeOffset.Now
            };
            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.Save(cancellationToken);  

            return new ApiResponse<CategoryCreateDto>(_mapper.Map<CategoryCreateDto>(category),"Category Added Successfully");
        }
    }
}
