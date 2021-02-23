using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingExperiments.Dtos
{
    public class ProductVariantDto
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
