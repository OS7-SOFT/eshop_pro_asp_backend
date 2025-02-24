using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Intrefaces;
using EShopPro.Domain.Common;
using EShopPro.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper.QueryableExtensions;


namespace EShopPro.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : PagedRequest, IRequest<ApiResponse<PagedList<CategoryDto>>>
    {
        public CategoryFilterCriteria? Filter { get; set; }
    }

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<PagedList<CategoryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PagedList<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filteredQuery = _unitOfWork.Repository<Category>().Entities;

            if (request.Filter is not null)
                filteredQuery = await _unitOfWork.Repository<Category>().ApplyFiltering(request.Filter);

            var totalRecords = await filteredQuery.CountAsync();

            var categories = await filteredQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

            if (!categories.Any())
                return new ApiResponse<PagedList<CategoryDto>>("Category is Empty", "No There any Category");

            var pagedList = PagedList<CategoryDto>.Create(categories, request.PageNumber, request.PageSize, totalRecords);
            return new ApiResponse<PagedList<CategoryDto>>(pagedList, "Categories geted Successfully");

        }
    }
}
