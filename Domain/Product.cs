using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace MappingExperiments.Domain
{
    // [name] is the class we are in
    [AdaptTo("[name]CodeGenDto"), GenerateMapper]
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public List<ProductVariant> Options { get; set; }
        public ProductVariant DefaultOption { get; set; }
    }
}
