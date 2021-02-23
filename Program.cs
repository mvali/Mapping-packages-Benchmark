using System;
using BenchmarkDotNet.Running;

namespace MappingExperiments
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MappingBenchmarks>(); 
        }
    }
}
