using AutoMapper;
using AutoMapper.QueryableExtensions;
using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Intrefaces;
using EShopPro.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.Categories.Queries
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;

    public class GetAllCategoriesHandlers : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Category>().GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(products);
        }
    }
}
