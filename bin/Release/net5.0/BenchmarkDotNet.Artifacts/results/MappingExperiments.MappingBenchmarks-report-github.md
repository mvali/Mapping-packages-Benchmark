``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.836 (1909/November2018Update/19H2)
Intel Core i5 CPU M 580 2.67GHz, 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.103
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT


```
|                    Method |     Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |---------:|---------:|---------:|------:|------:|------:|----------:|
|    MapsterAdaptWithConfig | 13.13 μs | 1.531 μs | 4.467 μs |     - |     - |     - |     352 B |
| MapsterAdaptWithoutConfig | 14.08 μs | 1.732 μs | 5.080 μs |     - |     - |     - |     352 B |
|        MapsterAdaptToType | 15.85 μs | 1.887 μs | 5.565 μs |     - |     - |     - |     392 B |
|                AutoMapper | 17.68 μs | 2.160 μs | 6.267 μs |     - |     - |     - |     360 B |
|                 ManualMap | 23.65 μs | 2.018 μs | 5.725 μs |     - |     - |     - |     424 B |
|             ExpressMapper | 32.61 μs | 3.021 μs | 8.812 μs |     - |     - |     - |     520 B |
