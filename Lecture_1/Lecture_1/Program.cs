using System;

namespace Lecture_1
{
    class Program
    {
        enum eState
        {
            Main,
            Game,
        }

        static void Main(string[] args)
        {
            // 기본 자료형의 선언
            {
                byte a = 4;
                short b = -30000;
                long d = -5000;
                char f = 'f';

                float g = 3.5f;
                double h = 6.4f;
                bool i = false;
            }

            // int 안에 함수가 있다고?
            {
                int a = 84;
                Console.WriteLine(a.ToString());
            }

            // object 안으로 모여!
            {
                int a = 123;
                object b = (object)a;           // a에 담긴 값을 박싱해서 힘에 저장
                int c = (int)b;                 // b에 담긴 값을 언박싱해서 스택에 저장
                Console.WriteLine(c.ToString());
            }

            // 상수
            {
                const int a = 3;
                const double b = 3.14;
                const string c = "test";

                //a = 2;
            }

            // enum
            {
                eState state = eState.Game;
                state = eState.Main;

                int index = (int)state;
            }

            // var
            {
                var a = 3;          // a는 int 형식
                var b = "Hello";    // b는 string 형식
            }

            // string
            {
                // 문자열 연결
                string test1 = "apple " + "banana";
                test1 += "pine apple.";
                Console.WriteLine(test1);

                // 변수나 값을 문자열로 합쳐서 처리
                Console.WriteLine(string.Format("{0} {1} 출력", 1, 5.5));

                // IndexOf
                string test2 = "apple banana";
                Console.WriteLine(test2.IndexOf("banana"));

                // StartWith
                string test3 = "apple banana";
                Console.WriteLine(test3.StartsWith("apple"));

                // Contains
                string test4 = "apple banana";
                Console.WriteLine(test4.Contains("apple"));

                // Replace
                string test5 = "apple banana";
                Console.WriteLine(test5.Replace("apple", "banana"));

                // ToLower / ToUpper
                string test6 = "apple banana";
                string test7 = "APPLE BANANA";
                Console.WriteLine(test6.ToUpper());
                Console.WriteLine(test7.ToLower());

                // Insert / Remote
                string test8 = "apple banana";
                string test9 = "apple banana";
                Console.WriteLine(test8.Insert(5, "asd"));
                Console.WriteLine(test9.Remove(5, 8));

                // Split
                string words = "apple,test1,test2";
                string[] arr = words.Split(',');

                foreach (string element in arr)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
