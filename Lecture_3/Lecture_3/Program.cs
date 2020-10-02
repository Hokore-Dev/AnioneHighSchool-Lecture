using System;

namespace Lecture_3
{
    class Base
    {
        public int hp = 0;
        protected string name = string.Empty;
        private float speed = 1.5f;

        public Base(string name)
        {
            this.name = name;
        }

        public void BaseMethod()
        {
            Console.WriteLine("Speed : {0}, Hp : {1}, Name : {2}",speed, hp, name);
        }
    }

    class Derived : Base
    {
        public Derived(string name) : base(name)
        {
            Console.WriteLine("{0} Derived()", name);
        }

        public void PrintAll()
        {
            /**
             *  hp    public     : 접근 가능
             *  name  protected  : 접근 가능 (상속 클래스는 접근 가능하게 만듬)
             *  speed private    : 접근 불가능 (선언 클래스만 접근 가능) 
             */
            Console.WriteLine("Hp : {0}, Name : {1}", hp, name);
        }
    }

    class Fruit
    {
        private class Leaf
        {
            public void Grow()
            {
                Console.WriteLine("Leaf Grow");
            }
        }

        public virtual void Grow()
        {
            Leaf leaf = new Leaf();
            leaf.Grow();

            Console.WriteLine("Grow");
        }
    }

    class Apple : Fruit
    {
        public override void Grow()
        {
            Console.WriteLine("Apple");
            base.Grow();
        }
    }

    class Banana : Fruit
    {
        public override void Grow()
        {
            Console.WriteLine("Banana");
            base.Grow();
        }
    }

    public static class LanguageExtension
    {
        public static string Locale(this string text, string language = "ko")
        {
            string locale = "UNKNOWN";
            if (text == "HELLO")
            {
                if (language == "en")
                {
                    locale = "hello";
                }
                else if (language == "ko")
                {
                    locale = "안녕하세요";
                }
            }
            return locale;
        }
    }

    public struct Vector2
    {
        public float x;
        public float y;

        public override string ToString()
        {
            return string.Format("{0} {1}", x, y);
        }
    }

    interface IDrinkable
    {
        void Drink();
    }

    interface IChewable
    {
        string Property
        {
            get;
        }
        void Chew();
    }

    class SnackBarFood
    {
    }

    class Lipton : SnackBarFood, IDrinkable
    {
        public string Name { get; set; } = string.Empty;

        public void Drink()
        { }
    }

    class Nacho : SnackBarFood, IChewable
    {
        public string Property
        {
            get
            {
                return "PROPERTY";
            }
        }
        private string _name;

        public string GetName()
        {
            return _name;
        }

        public Nacho(string name)
        {
            this._name = name;
        }

        public void Chew()
        { }
    }

    class Unit
    {
        // ... 공통되는 메서드도 구현해보고
    }

    class Player : Unit // 인터페이스도 붙여보고...
    {
        // Monster와 다른 걸로 구현도 해보고...
    }

    class Monster : Unit
    {
        // Player와 다른 걸로 구현도 해보고
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 상속
            {
                Derived derived = new Derived("엄준식");
                derived.BaseMethod();
                derived.hp = 5;
            }
            
            // is
            {
                Base baseClass = new Derived("테스트");
                Derived derived = null;

                if (baseClass is Derived)
                {
                    derived = (Derived)baseClass;
                    derived.PrintAll();
                }
            }

            // as
            {
                Base baseClass = new Derived("테스트");
                Derived derived = baseClass as Derived;
                if (derived != null)
                {
                    derived.PrintAll();
                }
            }

            // virtual override
            {
                Apple apple = new Apple();
                Banana banana = new Banana();

                apple.Grow();
                banana.Grow();
            }

            // Extension
            {
                Console.WriteLine("HELLO".Locale());
                Console.WriteLine("HELLO".Locale("en"));
            }

            // Struct
            {
                Vector2 point = new Vector2();
                point.x = 2;
                point.y = 5;
                Console.Write(point.ToString());
            }
        }
    }
}
