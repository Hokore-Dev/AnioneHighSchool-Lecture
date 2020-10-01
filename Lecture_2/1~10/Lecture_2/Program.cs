using System;

namespace Lecture_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // if, else, else if
            {
                bool test = false;
                if (test)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                int test1 = 2;
                if (test1 == 1)
                {
                    // if
                }
                else if (test1 == 2)
                {
                    // else if
                }
                else
                {
                    // else
                }
            }

            // switch
            {
                char character = 'c';
                switch (character)
                {
                    case 'a':
                        Console.WriteLine("a");
                        break;
                    case 'b':
                    case 'c':
                        Console.WriteLine("b or c");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }

            // while, do while
            {
                int count = 0;
                while(count < 5)
                {
                    Console.WriteLine(count);
                    count++;
                }

                do
                {
                    Console.WriteLine(count);
                } while (count < 0);
            }

            // for, foreach
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                }

                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }

            // break, continue
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i > 5)
                        break;

                    Console.WriteLine(i);
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                        continue;

                    Console.WriteLine(i);
                }
            }

            // method
            {
                TestMethod();

                // parameter funcation
                int result = Plus(2, 5);
                Console.WriteLine(result);
            }

            // ref, out
            {
                // ref
                int test = 1;
                RefFunc(ref test);
                Console.WriteLine(test);

                // out
                if (Divide(2, 5, out int result))
                {
                    Console.WriteLine(result);
                }
            }
        }

        private static bool Divide(int num1, int num2, out int result)
        {
            if (num2 == 0)
            {
                result = 0;
                return false;
            }
            result = num1 / num2;
            return true;
        }

        private static void RefFunc(ref int test)
        {
            test++;
        }

        private static int Plus(int a, int b)
        {
            return a + b;
        }

        private static void TestMethod()
        {
            Console.WriteLine("TestMethod");
        }
    }
}
