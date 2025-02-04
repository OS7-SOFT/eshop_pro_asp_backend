using EShopPro.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Features.Categories.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
