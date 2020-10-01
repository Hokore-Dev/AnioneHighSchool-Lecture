using System;

namespace Lecture_2
{
    public class Cat
    {
        public string Name;
        public string Color;

        public Cat()
        {
            Name = "이름 없음";
            Console.WriteLine("생성자1 호출!");
        }

        public Cat(string name) : this()
        {
            this.Name = name;
            Console.WriteLine("생성자2 호출!");
        }

        public Cat(string name, string color) : this(name)
        {
            this.Color = color;
            Console.WriteLine("생성자3 호출!");
        }

        ~Cat()
        {
            Console.WriteLine("소멸자 호출!");
        }

        public void Meow()
        {
            Console.WriteLine("{0} : 야옹", Name);
        }
    }

    public class StaticCat
    {
        public static string Name;
        public static string Color;

        public static void Meow()
        {
            Console.WriteLine("{0} : 야옹", Name);
        }
    }

    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        static int Add(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }

        static int Add(params int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        static string DefaultParam(string test1, string test2 = "World")
        {
            return test1 + test2;
        }

        static void Main(string[] args)
        {
            // 함수 오버로딩
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(1, 2, 3));
            Console.WriteLine(Add(1, 2, 3, 4));

            // 가변 인자
            Console.WriteLine(Add(1, 2, 3, 4, 5, 6));

            // 디폴트 매개 변수
            Console.WriteLine(DefaultParam("Hello"));
            Console.WriteLine(DefaultParam("Hello", "C#"));

            // 클래스의 생성
            Cat kitty = new Cat();
            kitty.Color = "하얀색";
            kitty.Name = "키티";
            kitty.Meow();
            Console.WriteLine("{0} : {1}", kitty.Name, kitty.Color);

            // 생성자 활용 
            Cat nabi = new Cat("나비", "갈색");
            nabi.Meow();
            Console.WriteLine("{0} : {1}", nabi.Name, nabi.Color);

            Cat copyCat = kitty;
            kitty.Name = "진짜 키티";
            copyCat.Name = "복사된 키티";

            copyCat.Meow();
            kitty.Meow();

            StaticCat.Name = "모두의 고양이";
            StaticCat.Color = "하얀색";
            Console.WriteLine("{0} : {1}", StaticCat.Name, StaticCat.Color);

            
        }
    }
}
