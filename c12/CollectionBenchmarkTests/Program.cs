using BenchmarkDotNet.Running;

namespace CollectionBenchmarkTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spread operator benchmarking");

            var summaryInitProperties = BenchmarkRunner.Run<InlineArraysTests>();
        }
    }
}
