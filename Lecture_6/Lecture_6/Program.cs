using System.Threading;
using System;

namespace Lecture_6
{
    class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DomeSomething : {i}");
            }
        }

        static void DoSomethingWithSleep()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine($"DomeSomething : {i}");
            }
        }

        static void DoSomethingWithAbort()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"DomeSomething : {i}");
                }
            }
            catch(ThreadAbortException ex)
            {
                
            }
        }

        class Counter
        {
            public int count = 0;
            private readonly object thisLock = new object();
            public void Increase()
            {
                // 필요한 구간에만 좁게!
                lock (thisLock)
                {
                    count = count + 1;
                }
            }
        }

        static void Main(string[] args)
        {
            // 기본 사용
            {
                // Thread 인스턴스 생성
                Thread t1 = new Thread(new ThreadStart(DoSomething));

                t1.Start();     // 스레드 시작
                t1.Join();      // 스레드 종료 대기
            }

            // 동시성 테스트
            {
                Thread t1 = new Thread(new ThreadStart(DoSomethingWithSleep));

                Console.WriteLine("Starting Thread");
                t1.Start();

                for (int i = 0; i< 5;i++)
                {
                    Console.WriteLine($"Main {i}");
                    Thread.Sleep(10);
                }

                Console.WriteLine("Waiting");

                t1.Join();

                Console.WriteLine("Finish");
            }

            // 종료
            {
                Thread t1 = new Thread(new ThreadStart(DoSomethingWithAbort));

                t1.Start();

                t1.Abort();     // 조심!!

                t1.Join();

                Thread t2 = new Thread(new ThreadStart(DoSomethingWithAbort));

                t2.Start();

                t2.Interrupt();

                t2.Join();
            }

            // lock
            {
                Counter counter = new Counter();
                Thread t1 = new Thread(new ThreadStart(counter.Increase));
                Thread t2 = new Thread(new ThreadStart(counter.Increase));
                Thread t3 = new Thread(new ThreadStart(counter.Increase));

                t1.Start();
                t2.Start();
                t3.Start();

                t1.Join();
                t2.Join();
                t3.Join();
            }
            
        }
    }
}
