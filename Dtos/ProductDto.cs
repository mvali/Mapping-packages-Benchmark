using System;
using System.Collections.Generic;

namespace MappingExperiments.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductName{ get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public List<ProductVariantDto> Options{ get; set; }
        public ProductVariantDto DefaultOption { get; set; }
    }
}
