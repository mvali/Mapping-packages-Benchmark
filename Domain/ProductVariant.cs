using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingExperiments.Domain
{
    // name defines the classname we are in
    [AdaptTo("[name]CodeGenDto"), GenerateMapper]
    public class ProductVariant
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
