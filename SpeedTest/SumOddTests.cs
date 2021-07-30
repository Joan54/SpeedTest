namespace SpeedTest
{
    public class SumOddTests
    {
        public static int SumOdd(int[] array)
        {
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];

                if (element % 2 != 0)
                {
                    counter += element;
                }
            }

            return counter;
        }

        public static int SumOdd_Bit(int[] array)
        {
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];

                if ((element & 1) == 1)
                {
                    counter += element;
                }
            }

            return counter;
        }

        public static int SumOdd_Bit_Branchless(int[] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                int odd = element & 1;

                counter += odd * element;
            }

            return counter;
        }

        public static int SumOdd_Bit_Branchless_Parallel(int[] array)
        {
            int counterA = 0;
            int counterB = 0;

            for (int i = 0; i < array.Length; i += 2)
            {
                int elementA = array[i];
                int elementB = array[i + 1];

                int oddA = elementA & 1;
                int oddB = elementB & 1;

                counterA += oddA * elementA;
                counterB += oddB * elementB;
            }

            return counterA + counterB;
        }

        public static int SumOdd_Bit_Branchless_Parallel_NoMult(int[] array)
        {
            int counterA = 0;
            int counterB = 0;

            for (int i = 0; i < array.Length; i += 2)
            {
                int elementA = array[i];
                int elementB = array[i + 1];

                counterA += (elementA << (elementA & 1)) - elementA;
                counterB += (elementB << (elementB & 1)) - elementB;
            }

            return counterA + counterB;
        }

        public static unsafe int SumOdd_Bit_Branchless_Parallel_NoChecks(int[] array)
        {
            int counterA = 0;
            int counterB = 0;

            fixed (int* intPtr = &array[0])
            {
                int* p = intPtr;

                for (int i = 0; i < array.Length; i += 2)
                {
                    counterA += (p[0] & 1) * p[0];
                    counterB += (p[1] & 1) * p[1];

                    p += 2;
                }
            }

            return counterA + counterB;
        }

        public static unsafe int SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports(int[] array)
        {
            int counterA = 0;
            int counterB = 0;
            int counterC = 0;
            int counterD = 0;

            fixed (int* intPtr = &array[0])
            {
                int* p = intPtr;

                for (int i = 0; i < array.Length; i += 4)
                {
                    counterA += (p[0] & 1) * p[0];
                    counterB += (p[1] & 1) * p[1];
                    counterC += (p[2] & 1) * p[2];
                    counterD += (p[3] & 1) * p[3];

                    p += 4;
                }
            }

            return counterA + counterB + counterC + counterD;
        }

        public static unsafe int SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts(int[] array)
        {
            int counterA = 0;
            int counterB = 0;
            int counterC = 0;
            int counterD = 0;

            fixed (int* intPtr = &array[0])
            {
                int* p = intPtr;
                int* n = p;

                for (int i = 0; i < array.Length; i += 4)
                {
                    counterA += (n[0] & 1) * p[0];
                    counterB += (n[1] & 1) * p[1];
                    counterC += (n[2] & 1) * p[2];
                    counterD += (n[3] & 1) * p[3];

                    p += 4;
                    n += 4;
                }
            }

            return counterA + counterB + counterC + counterD;
        }

        public static unsafe int SumOdd_Bit_Branchless_Parallel_NoChecks_4Ports_BetterPorts_NoMult(int[] array)
        {
            int counterA = 0;
            int counterB = 0;
            int counterC = 0;
            int counterD = 0;

            fixed (int* intPtr = &array[0])
            {
                int* p = intPtr;
                int* n = p;

                for (int i = 0; i < array.Length; i += 4)
                {
                    counterA += (0 - (p[0] & 1)) & p[0];
                    counterB += (0 - (p[1] & 1)) & p[1];
                    counterC += (0 - (p[2] & 1)) & p[2];
                    counterD += (0 - (p[3] & 1)) & p[3];

                    p += 4;
                    n += 4;
                }
            }
            return counterA + counterB + counterC + counterD;
        }

        public static unsafe int SumOdd_Bit_Branchless_Parallel_NoChecks_8Ports_BetterPorts(int[] array)
        {
            int counterA = 0;
            int counterB = 0;
            int counterC = 0;
            int counterD = 0;
            int counterE = 0;
            int counterF = 0;
            int counterG = 0;
            int counterH = 0;

            fixed (int* intPtr = &array[0])
            {
                int* p = intPtr;
                int* n = p;

                for (int i = 0; i < array.Length; i += 8)
                {
                    counterA += (n[0] & 1) * p[0];
                    counterB += (n[1] & 1) * p[1];
                    counterC += (n[2] & 1) * p[2];
                    counterD += (n[3] & 1) * p[3];
                    counterE += (n[4] & 1) * p[4];
                    counterF += (n[5] & 1) * p[5];
                    counterG += (n[6] & 1) * p[6];
                    counterH += (n[7] & 1) * p[7];

                    p += 8;
                    n += 8;
                }
            }

            return counterA + counterB + counterC + counterD + counterE + counterF + counterC + counterH;
        }
    }
}
