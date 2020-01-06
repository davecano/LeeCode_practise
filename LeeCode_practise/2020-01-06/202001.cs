using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace _2020_01_06
{
    public class _202001:Singleton<_202001>
    {
        #region 按序打印
        class Foo
        {
            /*
             * 第一种方式
             * */
            //private AutoResetEvent _second = new AutoResetEvent(false);
            //private AutoResetEvent _three = new AutoResetEvent(false);


            //public Foo()
            //{

            //}

            //public void First(Action printFirst)
            //{
            //    printFirst();
            //    _second.Set();//通知第二个可以执行了
            //}

            //public void Second(Action printSecond)
            //{
            //    _second.WaitOne();//等待通知
            //    printSecond();
            //    _three.Set();//通知第三个可以执行了

            //}

            //public void Third(Action printThird)
            //{
            //    _three.WaitOne();//等待通知
            //    printThird();
            //}

            //第二种方式，使用自旋锁
            //private SpinWait _spinWait = new SpinWait();
            //private int _continueCondition = 1;

            //public Foo()
            //{

            //}
            //public void First(Action printFirst)
            //{
            //    printFirst();
            //    Thread.VolatileWrite(ref _continueCondition, 2);//写栅栏
            //}

            //public void Second(Action printSecond)
            //{

            //    while (Thread.VolatileRead(ref _continueCondition) != 2)
            //    {
            //        _spinWait.SpinOnce();
            //    }
            //    printSecond();
            //    Thread.VolatileWrite(ref _continueCondition, 3);//写栅栏
            //}

            //public void Third(Action printThird)
            //{
            //    while (Thread.VolatileRead(ref _continueCondition) != 3)
            //    {
            //        _spinWait.SpinOnce();
            //    }
            //    printThird();
            //    Thread.VolatileWrite(ref _continueCondition, 1);//写栅栏
            //}

            #region 自己实现
          
                public volatile int i=0;
            public Foo()
            {

            }
            public void First(Action printFirst)
            {
                while(i!=0) continue;
                printFirst();
                i++;

            }

            public void Second(Action printSecond)
            {

                while (i != 1) continue;
                printSecond();
                i++;
            }

            public void Third(Action printThird)
            {
               while(i!=2) continue; 
                printThird();
                i=0;
            }



            #endregion
        }
        #endregion
        #region 交替打印FooBar https://leetcode-cn.com/problems/print-foobar-alternately/

        //internal class FooBar
        //{
        //    private int n;
        //    private volatile int t = 0;
        //    public FooBar(int n)
        //    {
        //        this.n = n;
        //    }

        //    public void Foo(Action printFoo)
        //    {

        //        for (int i = 0; i < n; i++)
        //        {
        //            while(0!=t) continue;
        //            printFoo();
        //            t = 1;
        //        }
        //    }

        //    public void Bar(Action printBar)
        //    {

        //        for (int i = 0; i < n; i++)
        //        {


        //            while (1 != t) continue;
        //            printBar();
        //            t = 0;
        //        }
        //    }
        //}
        //internal class FooBar
        //{
        //    private int n;
        //    private AutoResetEvent autoResetEvent1=new AutoResetEvent(false);
        //    private AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
        //    public FooBar(int n)
        //    {
        //        this.n = n;
        //    }

        //    public void Foo(Action printFoo)
        //    {

        //        for (int i = 0; i < n; i++)
        //        {
        //            if (i != 0)
        //            {
        //                autoResetEvent1.WaitOne();
        //            }
        //            printFoo();
        //            autoResetEvent2.Set();
        //        }
        //    }

        //    public void Bar(Action printBar)
        //    {

        //        for (int i = 0; i < n; i++)
        //        {
        //            autoResetEvent2.WaitOne();
        //            printBar();
        //            autoResetEvent1.Set();

        //        }
        //    }
        //}
        //自旋锁也可实现，
        internal class FooBar
        {
            private int n;
            //第一个参数初始信号量，第二个参数最大信号量（最多允许N个线程同时使用）
            //交替打印按顺序打印，所以最大信号量是1
            private Semaphore foo = new Semaphore(1, 1);//先打印foo，所以加入一个初始信号量
            private Semaphore bar = new Semaphore(0, 1);//后打印，所以不加入信号量，等待foo打印后在加入信号量
            public FooBar(int n)
            {
                this.n = n;
            }

            public void Foo(Action printFoo)
            {
                for (int i = 0; i < n; i++)
                {
                    foo.WaitOne();//等待获取一个信号量
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    bar.Release(1);//为bar加入一个信号量
                }
            }

            public void Bar(Action printBar)
            {
                for (int i = 0; i < n; i++)
                {
                    bar.WaitOne();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    foo.Release(1);
                }
            }
        }

        #region Overrides of Object

        public void Display()
        {
            FooBar foo=new FooBar(4);
            Task.Run(() =>
            {
                foo.Bar(() => Console.Write("bar"));
            });
            Task.Run(() =>
            {
                foo.Foo(() => Console.WriteLine("foo"));
            });

        }

        #endregion

        #endregion
        #region  打印零与奇偶数 https://leetcode-cn.com/problems/print-zero-even-odd/?utm_source=LCUS&utm_medium=ip_redirect_q_uns&utm_campaign=transfer2china

        #endregion


    }
}
