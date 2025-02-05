using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Application.Features.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.Categories.Handlers
{
    public class GetAllCategoriesHandlers : IRequestHandler<GetAllCategoriesQueries, List<CategoryDto>>
    {
        public Task<List<CategoryDto>> Handle(GetAllCategoriesQueries request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
