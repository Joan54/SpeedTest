using BenchmarkDotNet.Attributes;
using System;

namespace SpeedTest
{
    [MemoryDiagnoser]
    [Orderer( BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest) ]
    [RankColumn]
    public class SumOddBenchmarks
    {
        int[] array = new int[40000000];

        public SumOddBenchmarks()
        {
            Random r = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(int.MinValue, int.MaxValue);
            }            
        }

        [Benchmark]
        public void SumOdd()
        {
            var count = SumOddTests.SumOdd(array);
        }

        [Benchmark]
        public void SumOdd_Bit()
        {
            var count = SumOddTests.SumOdd_Bit(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoMult()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoMult(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoChecks()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoChecks(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts_NoMult()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts_NoMult(array);
        }

        [Benchmark]
        public void SumOdd_Bit_Branchless_Parallel_NoChecks_8Ports_BetterPorts()
        {
            var count = SumOddTests.SumOdd_Bit_Branchless_Parallel_NoChecks_8Ports_BetterPorts(array);
        }
    }
}
