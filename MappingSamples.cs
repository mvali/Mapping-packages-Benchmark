using System.Linq;
using MappingExperiments.Dtos;
using Mapster;
using AutoMapper;
using System;
using MappingExperiments.Domain;
using System.Collections.Generic;

namespace MappingExperiments
{
    public class MappingSamples
    {
        private static readonly IMapper AutoMapper = new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutomapperProfile())));

        // mapster configuration
        private static readonly TypeAdapterConfig TypeAdapterConfig = GetTypeAdapterConfig();

        //private static readonly MapsterMapper.IMapper MapsterMapper = new MapsterMapper.Mapper(GetTypeAdapterConfig());
        private static readonly MapsterMapper.IMapper MapsterMapper = new MapsterMapper.Mapper(TypeAdapterConfig);

        static MappingSamples()
        {
            ExpressMapper.Mapper.Register<Product, ProductDto>();
        }

        public static ProductDto ExpressMapSample()
        {
            return ExpressMapper.Mapper.Map<Product, ProductDto>(GenerateProduct);
        }

        internal static ProductDto MapsterAdaptWithoutConfigSample()
        {
            // mapping will be done dynamically, but does not allow any configuration
            return GenerateProduct.Adapt<ProductDto>();
        }
        internal static ProductDto MapsterAdaptWithConfigSample()
        {
            return GenerateProduct.Adapt<ProductDto>(TypeAdapterConfig);
        }

        // real world scenario
        internal static ProductDto MapsterAdaptToTypeSample()
        {
            return MapsterMapper.From(GenerateProduct).AdaptToType<ProductDto>();
        }

        public static ProductDto AutoMapSample()
        {
            return AutoMapper.Map<ProductDto>(GenerateProduct);
        }
        public static ProductDto ManualMapSample()
        {
            var product = GenerateProduct;
            var dto = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Weight = product.Weight,
                ProductName = product.ProductName,
                DefaultOption = new ProductVariantDto
                {
                    Id = product.DefaultOption.Id,
                    Color = product.DefaultOption.Color,
                    Size = product.DefaultOption.Size
                }
                // example 1 slower
                /*,Options = product.Options.Select(x => new ProductVariantDto
                {
                    Color = x.Color,
                    Id = x.Id,
                    Size = x.Size
                }).ToList() */
            };

            // example 2 faster then 1
            var options = new List<ProductVariantDto>();
            for (int i = 0; i < product.Options.Count; i++)
            {
                options.Add(new ProductVariantDto
                {
                    Id = product.Options[i].Id,
                    Size = product.Options[i].Size,
                    Color = product.Options[i].Color
                });
            }
            dto.Options = options;

            return dto;
        }
        public static ProductDto ManualMapSampleOptionsSelect()
        {
            var product = GenerateProduct;
            var dto = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Weight = product.Weight,
                ProductName = product.ProductName,
                DefaultOption = new ProductVariantDto
                {
                    Id = product.DefaultOption.Id,
                    Color = product.DefaultOption.Color,
                    Size = product.DefaultOption.Size
                }
                // example 1 slower
                ,Options = product.Options.Select(x => new ProductVariantDto
                {
                    Color = x.Color,
                    Id = x.Id,
                    Size = x.Size
                }).ToList()
            };

            // example 2 faster then 1
            /*var options = new List<ProductVariantDto>();
            for(int i=0; i < product.Options.Count; i++)
            {
                options.Add(new ProductVariantDto 
                { 
                    Id=product.Options[i].Id,
                    Size=product.Options[i].Size,
                    Color=product.Options[i].Color
                });
            }
            dto.Options = options;*/

            return dto;
        }
        public static ProductDto ManualMapSampleOptionsFor()
        {
            var product = GenerateProduct;
            var dto = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Weight = product.Weight,
                ProductName = product.ProductName,
                DefaultOption = new ProductVariantDto
                {
                    Id = product.DefaultOption.Id,
                    Color = product.DefaultOption.Color,
                    Size = product.DefaultOption.Size
                }
                // example 1 slower
                /*,Options = product.Options.Select(x => new ProductVariantDto
                {
                    Color = x.Color,
                    Id = x.Id,
                    Size = x.Size
                }).ToList() */
            };

            // example 2 faster then 1
            var options = new List<ProductVariantDto>();
            for (int i = 0; i < product.Options.Count; i++)
            {
                options.Add(new ProductVariantDto
                {
                    Id = product.Options[i].Id,
                    Size = product.Options[i].Size,
                    Color = product.Options[i].Color
                });
            }
            dto.Options = options;

            return dto;
        }
        public static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Product, ProductDto>();
            return config;
        }

        public static readonly Product GenerateProduct = new()
        {
            Id = Guid.Parse("12293887-4B11-4C98-9DF4-9240AF37B60B"),
            Description = "desctiption that needs to be mapped",
            Weight = 69m,
            ProductName = "The Best Map",
            DefaultOption = new ProductVariant
            {
                Id = Guid.Parse("12293887-4B11-4C98-9DF4-9240AF37B60B"),
                Color = "Red",
                Size = "Small"
            },
            Options = new List<ProductVariant>
            {
                new()
                {
                    Id=Guid.Parse("12293887-4B11-4C98-9DF4-9240AF37B60B"),
                    Color="Red",
                    Size="Small"
                },
                new()
                {
                    Id=Guid.Parse("12293887-4B11-4C98-9DF4-9240AF37B60B"),
                    Color="Blue",
                    Size="Medium"
                },
                new()
                {
                    Id=Guid.Parse("12293887-4B11-4C98-9DF4-9240AF37B60B"),
                    Color="Green",
                    Size="Large"
                }
            }
        };
    }

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductVariant, ProductVariantDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
