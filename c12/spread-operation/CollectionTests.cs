using BenchmarkDotNet.Attributes;

namespace SpreadOperator
{
    [MemoryDiagnoser]
    public class CollectionTests
    {
        int n = 10000;
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] row2 = [7, 8, 9];

        [Benchmark]
        public void Jagged2DBencharmkTest() { 
            for (int i = 0; i < n; i++)
            {
                int[][] twoDFromVariables = [row0, row1, row2];
            }
        }

        [Benchmark]
        public void JaggedWithSpreadOperatorBencharmkTest()
        {
            for (int i = 0; i < n; i++)
            {
                int[] twoDFromVariables = [..row0, ..row1, ..row2];
            }
        }
    }
}
