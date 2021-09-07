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
    #region asp.net core中间件
    public delegate Task ResquestDelegate(HttpContext context);

    public class ApplicationBuilder
    {


        public IList<Func<ResquestDelegate, ResquestDelegate>> _components;
        public ResquestDelegate _endMethod;
        public ApplicationBuilder()
        {
            _components = new List<Func<ResquestDelegate, ResquestDelegate>>();
        }
        public ApplicationBuilder Use(Func<ResquestDelegate, ResquestDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }
        public ApplicationBuilder Run(ResquestDelegate EndMethod)
        {
            _endMethod = EndMethod;
            return this;
        }

        public ResquestDelegate Build()
        {
            //ResquestDelegate rd = x => x.ResponseAsync("您还未添加任何中间件！！！");
            ResquestDelegate rd;
            if (_endMethod == null)
            {
                rd = x =>
                {
                    Console.WriteLine("没有结束中间件！！！！！！");
                    throw new Exception();
                };
            }
            else
            {
                rd = _endMethod;
            }

            foreach (var middleware in _components.Reverse())
            {
                rd = middleware(rd);
            }

            return rd;
        }
    }

    public class HttpContext
    {
        public Task ResponseAsync(string content)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(content);
            });
        }
    }

    public static class TerminalMiddleware
    {
        public static void Display()
        {
            var _applicationBuilder = new ApplicationBuilder();

            Func<ResquestDelegate, ResquestDelegate> middleware = x =>
            {
                //当前要执行的委托
                ResquestDelegate _currentDelegate = async context =>
                {
                    // await  context.ResponseAsync("执行的第一个中间件开始");
                    Console.WriteLine("执行的第一个中间件开始");
                    await x(context);
                    Console.WriteLine("执行的第一个中间件结束");
                };
                return _currentDelegate;

            };
            Func<ResquestDelegate, ResquestDelegate> middleware2 = x =>
            {
                //当前要执行的委托
                ResquestDelegate _currentDelegate = async context =>
                {
                    //await context.ResponseAsync("执行的第二个中间件开始");
                    Console.WriteLine("执行的第二个中间件开始");
                    await x(context);
                    Console.WriteLine("执行的第二个中间件结束");
                };
                return _currentDelegate;
            };
            try
            {
                _applicationBuilder.Use(middleware);
                _applicationBuilder.Use(middleware2);
                _applicationBuilder.Run(x =>
                {
                    Console.WriteLine("结束中间件");
                    return Task.CompletedTask;
                });
                var lastDelegate = _applicationBuilder.Build();

                lastDelegate(new HttpContext());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }

        }

    }
    #endregion
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



