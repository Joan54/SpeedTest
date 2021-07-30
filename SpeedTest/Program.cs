using BenchmarkDotNet.Running;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Debug = 462 ms; Release = 218 ms
            //count = SumOdd(array);
            // Debug = 294 ms; Release = 123 ms
            //count = SumOdd_Bit(array);
            // Debug = 111 ms; Release = 19 ms
            //count = SumOdd_Bit_Branchless(array);
            // Debug = 85 ms; Release = 30 ms
            //count = SumOdd_Bit_Branchless_Parallel(array);
            // Debug = 83 ms; Release = 65 ms
            //count = SumOdd_Bit_Branchless_Parallel_NoMult(array);
            // Debug = 55 ms; Release = 28 ms
            //count = SumOdd_Bit_Branchless_Parallel_NoChecks(array);
            // Debug = 41 ms; Release = 16 ms
            //count = SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports(array);
            // Debug = 43 ms; Release = 17 ms
            //count = SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts(array);
            // Debug = 46 ms; Release = 19 ms
            //count = SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts_NoMult(array);

            BenchmarkRunner.Run<SumOddBenchmarks>();
        }
    }
}
