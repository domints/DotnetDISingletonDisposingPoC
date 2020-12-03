using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetDISingletonDisposingPoC
{
    public static class ServiceInjector
    {
        static IServiceProvider _services;

        static Stack<IServiceScope> _scopeStack;

        static IServiceProvider _provider => _scopeStack.NullPeek()?.ServiceProvider ?? _services;

        public static void Configure()
        {
            var svcCollection = new ServiceCollection();
            svcCollection.AddSingleton<ISampleSingletonService, SampleSingletonService>();

            _services = svcCollection.BuildServiceProvider();
            _scopeStack = new Stack<IServiceScope>();
        }

        public static T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public static void StartScope()
        {
            _scopeStack.Push(_services.CreateScope());
        }

        public static void KillAllScopes()
        {
            while(_scopeStack.TryPop(out IServiceScope scope))
            {
                scope.Dispose();
            }

            _services = null; // I also tried to convince GC to clean it up and force Dispose. Nope.
        }
    }
}