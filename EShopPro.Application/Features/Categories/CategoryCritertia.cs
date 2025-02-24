using EShopPro.Application.Common;
using EShopPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.Categories
{
    public class CategoryFilterCriteria : FilterCriteria<Category>
    {
        public string? Name { get; set; }

        public override Expression<Func<Category, bool>>? GetFilterExpression()
        {
            return category =>
                (string.IsNullOrEmpty(Name) || category.Name.Contains(Name)) &&
                (string.IsNullOrEmpty(SearchTerm) || category.Name.Contains(SearchTerm));
        }
    }
}
