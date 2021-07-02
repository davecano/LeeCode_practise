using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20200326
{
    //public delegate Task RequestDelegate(Context context);
    public delegate Task RequestDelegate(Context context);
    //public delegate TResult Func<[Nullable(2)] in T, [Nullable(2)] out TResult>(T arg);
    public class Context
    {
        private string request;

        public void SetRequest(string value)
        {
            request = value;
        }

        public async Task ResponseAsync(string response)
        {
            await Task.Run(() => Console.WriteLine($"收到{request},{response}"));
        }


    }
    public class _202003
    {

        #region 写个.net core的中间件把
        public static async Task main()
        {
            Context c = new Context();
            c.SetRequest("来自cx的请求");
            ApplicationCore application = new ApplicationCore();
            //第一个中间件
            application.Use(next => async context =>
            {
                await context.ResponseAsync("来自第1个中间件Start");
                await next(context);
                await context.ResponseAsync("来自第1个中间件End");
            })
            .Use(next => async context =>
            {
                await context.ResponseAsync("来自第2个中间件Start");
                await next(context);
                await context.ResponseAsync("来自第2个中间件End");
            })
            .Use(next => async context =>
            {
                await context.ResponseAsync("来自第3个中间件Start");
                await next(context);
                await context.ResponseAsync("来自第3个中间件End");
            })
            .Use(async (context, next) =>
            {
                await context.ResponseAsync("来自第4个中间件Start");
                await next();
                await context.ResponseAsync("来自第4个中间件End");
            })
            .Use(async (context, next) =>
            {
                await context.ResponseAsync("来自第5个中间件Start");
                //await next();
                await context.ResponseAsync("来自第5个中间件End");
            });

            RequestDelegate rd = application.Build();
            await rd(c);
        }

        internal class ApplicationCore
        {
            private readonly IList<Func<RequestDelegate, RequestDelegate>> list;
            public ApplicationCore()
            {
                list = new List<Func<RequestDelegate, RequestDelegate>>();
            }
            public ApplicationCore Use(Func<RequestDelegate, RequestDelegate> func)
            {
                list.Add(func);
                return this;
            }
            //把下面的参数编程上面的参数呗
            public ApplicationCore Use(Func<Context, Func<Task>, Task> middware)
            {
                Func<RequestDelegate, RequestDelegate> upParam = requestDelegate =>
                {
                    //得到一个requestDelegate
                    return context =>
                     {
                         //得到一个task
                         Func<Task> task = () => requestDelegate(context);
                         return middware(context, task);
                     };
                };
                return Use(upParam);
            }

            public RequestDelegate Build()
            {

                RequestDelegate defaultDelegate = async request =>
                {

                    await Task.Run(() => Console.WriteLine("这是第一个中间件哦，内置的"));
                };

                foreach (Func<RequestDelegate, RequestDelegate> item in list.Reverse())
                {
                    defaultDelegate = item(defaultDelegate);
                }
                return defaultDelegate;
            }
        }

        #endregion

        #region 写个rx.net 的基本用法
        public static void rxMain()
        {
            IObservable<int> sequence = GetTaskObservable();
            sequence.Subscribe
            (
                x => Console.WriteLine($"OnNext: {x}"),
                ex => Console.WriteLine($"OnError: {ex}"),
                () => Console.WriteLine("OnCompleted")
            );
            Console.ReadKey();
        }

        private static IObservable<int> GetSimpleObservable()
        {
            return Observable.Return(42);
        }

        private static IObservable<int> GetThrowObservable()
        {
            return Observable.Throw<int>(new ArgumentException("Error in observable"));
        }

        private static IObservable<int> GetEmptyObservable()
        {
            return Observable.Empty<int>();
        }

        private static IObservable<int> GetTaskObservable()
        {
            return GetTask().ToObservable();
        }

        private static async Task<int> GetTask()
        {
            return 42;
        }

        private static IObservable<int> GetRangeObservable()
        {
            return Observable.Range(2, 10);
        }

        private static IObservable<long> GetIntervalObservable()
        {
            return Observable.Interval(TimeSpan.FromMilliseconds(200));
        }

        private static IObservable<int> GetCreateObservable()
        {
            return Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                observer.OnNext(2);
                observer.OnNext(3);
                observer.OnNext(4);
                observer.OnCompleted();
                return Disposable.Empty;
            });
        }

        private static IObservable<int> GetGenerateObservable()
        {
            return Observable.Generate(
                1,
                x => x < 5,
                x => x + 1,
                x => x
            );
        }
    }

    #endregion
}



