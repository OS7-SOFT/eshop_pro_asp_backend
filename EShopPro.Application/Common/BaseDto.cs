using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Application.Common
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? updatedDate { get; set; }
    }
}
