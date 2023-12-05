using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SpreadOperator
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spread operator benchmarking");

            var summaryInitProperties = BenchmarkRunner.Run<CollectionTests>();
        }


    }
}
