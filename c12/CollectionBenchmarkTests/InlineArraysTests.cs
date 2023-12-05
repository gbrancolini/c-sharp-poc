using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace CollectionBenchmarkTests
{
    [MemoryDiagnoser]
    public  class InlineArraysTests
    {
        int n = 10000;

        [Benchmark]
        public void TestInlinedArray()
        {
            for (int i = 0; i < n; i++)
            {
                var inlinedArray = new InlinedArray();

                for (int j = 0; j < 10; j++)
                {
                    inlinedArray[j] = j;
                }
            }
        }

        [Benchmark]
        public void TestDefinedArray()
        {
            for (int i = 0; i < n; i++)
            {
                int[] tenElementArray = new int[10];

                for (int j = 0; j < 10; j++)
                {
                    tenElementArray[j] = j;
                }
            }
        }
    }

    [InlineArray(10)]
    public struct InlinedArray
    {
        private int _element0;
    }
}
