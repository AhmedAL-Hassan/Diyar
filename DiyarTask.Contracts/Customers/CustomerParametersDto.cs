using DiyarTask.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyarTask.Contracts.Customers
{
    public sealed class CustomerParametersDto
    {
        public string? Filters { get; set; }
        public string? SortOrder { get; set; }
    }
}
