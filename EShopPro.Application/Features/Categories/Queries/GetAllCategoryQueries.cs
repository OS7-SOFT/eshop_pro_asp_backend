using EShopPro.Application.Features.Categories.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQueries : IRequest<List<CategoryDto>>
    {
    }
}
