using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MappingExperiments.Domain;
using MappingExperiments.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MappingExperiments
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class MappingBenchmarks
    {
        //[Benchmark] public ProductDto ManualMapSelect() => MappingSamples.ManualMapSampleOptionsSelect();
        //[Benchmark] public ProductDto ManualMapOpFor() => MappingSamples.ManualMapSampleOptionsFor();
        [Benchmark] public ProductDto ManualMap() => MappingSamples.ManualMapSample();

        [Benchmark] public ProductDto ExpressMapper() => MappingSamples.ExpressMapSample();

        [Benchmark] public ProductDto AutoMapper() => MappingSamples.AutoMapSample();

        // mapster use codegeneration
        // console: dotnet new tool-manifest // will create project manifest
        //          dotnet tool install Mapster.Tool //install Mapster.Tool nuget
        [Benchmark] public ProductDto MapsterAdaptWithoutConfig() => MappingSamples.MapsterAdaptWithoutConfigSample();
        [Benchmark] public ProductDto MapsterAdaptWithConfig() => MappingSamples.MapsterAdaptWithConfigSample();
        [Benchmark] public ProductDto MapsterAdaptToType() => MappingSamples.MapsterAdaptToTypeSample();
    }

}
