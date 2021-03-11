# Mapping-packages-Benchmark
Console project in .Net Core v5 to see what automatic mapper takes less time to execute <br/>
Tests are done using : BenchmarkDotNet v0.12.1 <br/>
Mappers tested:
- Manual map
- AutoMapper v10.1.1
- ExpressMapper.Core v1.9.3
- Mapster v7.1.3
 <br/>
Results may vary depending on your processor and compiler used but for me results are listed below. <br/>
Thank you "jerviscui" for remind me to also post results. <br/>
 <br/>
.NET Core SDK=5.0.201 <br/>
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT <br/>

|                    Method |        Mean |     Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------------:|----------:|------------:|-------:|------:|------:|----------:|
|                AutoMapper |    516.8 ns |   2.81 ns |     2.63 ns | 0.1144 |     - |     - |     360 B |
|                 ManualMap |  4,573.0 ns | 310.53 ns |   860.47 ns |      - |     - |     - |     360 B |
|        MapsterAdaptToType | 11,337.1 ns | 890.20 ns | 2,466.75 ns |      - |     - |     - |     392 B |
| MapsterAdaptWithoutConfig | 11,713.3 ns | 233.91 ns |   350.11 ns |      - |     - |     - |     352 B |
|    MapsterAdaptWithConfig | 12,400.0 ns | 232.30 ns |   258.20 ns |      - |     - |     - |     352 B |
|             ExpressMapper | 24,697.8 ns | 608.24 ns | 1,685.43 ns |      - |     - |     - |     520 B |
