using System.Collections.Generic;
using System;

namespace Lecture_4
{
    class Program
    {
        static void CopyArray(int[] source, int[] target)
        {
            for (int i = 0; i< source.Length;i++)
                target[i] = source[i];
        }

        static void CopyArray(string[] source, string[] target)
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];
        }

        static void CopyArray<T>(T[] source, T[] target) where T : struct
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];
        }

        class MyList<T>
        {
            private T[] array;

            public T this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    if (index >= array.Length)
                    {
                        Array.Resize<T>(ref array, index + 1);
                        Console.WriteLine("Array Resized {0}", array.Length);
                    }
                    array[index] = value;
                }
            }

            public int Length
            {
                get { return array.Length; }
            }

            public MyList()
            {
                array = new T[3];
            }
        }

        static void Main(string[] args)
        {
            // array
            {
                int[] array1 = new int[3] { 1, 2, 3 };
                int[] array2 = new int[] { 1, 2, 3 };
                int[] array3 = { 1, 2, 3 };

                int[] scores = new int[5];
                scores[0] = 80;
                scores[1] = 90;
                scores[2] = 84;
                scores[3] = 92;
                scores[4] = 56;

                for (int i = 0; i < scores.Length; i++)
                {
                    Console.WriteLine(scores[i]);
                }

                Array.Sort(scores);

                for (int i = 0; i < scores.Length; i++)
                {
                    Console.WriteLine(scores[i]);
                }

                int index = Array.IndexOf(scores, 80);
                Console.WriteLine(scores[index]);
            }

            // generic method
            {
                float[] source = { 1.4f, 2.5f, 26.2f };
                float[] target = new float[source.Length];

                CopyArray(source, target);
            }

            // generic class
            {
                MyList<int> list = new MyList<int>();
                list[0] = 2;
                list[1] = 25;

                for (int i = 0; i < list.Length; i++)
                    Console.WriteLine(list[i]);
            }

            // list
            {
                List<int> list = new List<int>();
                for (int i = 0; i < 5; i++)
                    list.Add(i);

                list.RemoveAt(2);

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine(i);

                list.Insert(2, 2);

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine(i);
            }

            // queue
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);

                while (queue.Count > 0)
                {
                    Console.WriteLine(queue.Dequeue());
                }
            }

            // stack
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);

                while(stack.Count > 0)
                {
                    Console.WriteLine(stack.Pop());
                }
            }

            // dictionary & foreach
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

                dic["하나"] = "one";
                dic["둘"] = "two";
                dic["셋"] = "three";
                dic["넷"] = "four";
                dic["다섯"] = "five";

                foreach (var item in dic)
                {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
                }

                Console.WriteLine(dic["하나"]);
                Console.WriteLine(dic["둘"]);
                Console.WriteLine(dic["셋"]);
                Console.WriteLine(dic["넷"]);
                Console.WriteLine(dic["다섯"]);
            }

            // try catch
            {
                try
                {
                    int[] test = new int[3];
                    Console.WriteLine(test[6]);
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Process End");
                }

                try
                {
                    throw new Exception("의도된 에러");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
