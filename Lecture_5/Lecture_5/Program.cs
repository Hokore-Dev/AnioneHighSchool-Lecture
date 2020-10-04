using System.Collections.Generic;
using System;
using System.Linq;

namespace Lecture_5
{
    class Program
    {
        public delegate int MyDelegate(int a, int b);

        public float Speed
        {
            get => 1.0f;
            set => speed = value;
        }
        private float speed = 0;

        public float Count => 5;

        public void ChangeSpeed(float Speed) => this.Speed = Speed;

        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public static int Minus(int a, int b)
        {
            return a - b;
        }

        public static void Execute(MyDelegate callback)
        {
            callback(1, 2);
        }

        public delegate void ChangeHpDelegate(int hp);
        public static event ChangeHpDelegate hpEvent;

        private static void UpdateUI(int hp)
        {
            Console.WriteLine("UpdateUI");
        }

        private static void UpdateAchievement(int hp)
        {
            Console.WriteLine("UpdateAchievement");
        }

        private static void UpdateCharacter(int hp)
        {
            Console.WriteLine("UpdateCharacter");
        }

        class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }

        static void Main(string[] args)
        {
            // base delegate
            {
                MyDelegate callback;

                callback = new MyDelegate(Plus);
                Console.WriteLine(callback(1, 2));

                callback = new MyDelegate(Minus);
                Console.WriteLine(callback(2, 1));

                Execute(callback);
            }

            // delegate chain
            {
                ChangeHpDelegate changeHp = new ChangeHpDelegate(UpdateUI)
                                   + new ChangeHpDelegate(UpdateAchievement)
                                   + new ChangeHpDelegate(UpdateCharacter);

                changeHp(50);
            }

            // anonymous method
            {
                MyDelegate callback = null;

                callback = delegate (int a, int b)
                {
                    return a + b;
                };

                Console.WriteLine(callback(1,2));
            }

            // event
            {
                hpEvent += UpdateUI;
                hpEvent += UpdateAchievement;
                hpEvent += UpdateCharacter;

                hpEvent(40);
            }

            // lambda expression
            {
                MyDelegate callback = null;

                callback = (a, b) => a + b;

                callback = (a, b) =>
                {
                    return a + b;
                };
            }

            // func, action
            {
                Func<int, int, int> callback = null;

                callback = (a, b) => a + b;

                Console.WriteLine(callback(1,2));

                Action<int> action = null;
                action = (input) => Console.WriteLine("action 호출");
                action(5);
            }

            // LINQ
            {
                List<int> intList = new List<int>();
                int[] numbers = { 22, 11, 3, 9, 8, 1, 3, 6, 56 };

                // 짝수만 뽑아서 정렬해보자

                var data = from num in numbers
                           where num % 2 == 0
                           orderby num
                           select num;

                foreach (var num in data)
                    Console.WriteLine(num);

                Profile[] profiles =
                {
                    new Profile() { Name = "1번", Height = 186 },
                    new Profile() { Name = "2번", Height = 158 },
                    new Profile() { Name = "3번", Height = 172 },
                    new Profile() { Name = "4번", Height = 178 },
                    new Profile() { Name = "5번", Height = 171 },
                };

                var selectProfiles = from profile in profiles
                               where profile.Height < 175
                               orderby profile.Height
                               select new
                               {
                                   Name = profile.Name,
                                   InchHeight = profile.Height * 0.393f
                               };

                foreach (var profile in selectProfiles)
                {
                    Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
                }

                var groupProfiles = from profile in profiles
                                    orderby profile.Height
                                    group profile by profile.Height < 175 into g
                                    select new { GroupKey = g.Key, Profiles = g };

                foreach (var Group in groupProfiles)
                {
                    Console.WriteLine($"175 미만? : {Group.GroupKey}");

                    foreach (var profile in Group.Profiles)
                    {
                        Console.WriteLine($"{profile.Name}, {profile.Height}");
                    }
                }
            }
        }
    }
}
