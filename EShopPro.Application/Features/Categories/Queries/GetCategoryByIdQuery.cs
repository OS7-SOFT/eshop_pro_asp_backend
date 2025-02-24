using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Intrefaces;
using EShopPro.Domain.Common;
using MediatR;
using EShopPro.Domain.Entities;
using AutoMapper;

namespace EShopPro.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<ApiResponse<CategoryDto>>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);

            if (category == null)
            {
                return new ApiResponse<CategoryDto>("", "Category not Found");
            }

            return new ApiResponse<CategoryDto>(_mapper.Map<CategoryDto>(category), "Categroy geted Successfully");
        }
    }

}
