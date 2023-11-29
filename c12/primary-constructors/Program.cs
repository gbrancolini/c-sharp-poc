using BenchmarkDotNet.Running;

namespace primary_constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmarking");

            var summaryInitProperties = BenchmarkRunner.Run<PrimaryConstructorsBenchmarkTests>();
        }
    }
}