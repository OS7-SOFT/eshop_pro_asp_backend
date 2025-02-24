using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Common
{
    public abstract class FilterCriteria<T> where T : class
    {
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }

        public virtual Expression<Func<T, bool>>? GetFilterExpression() => null;
    }
}
