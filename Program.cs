using System;

namespace DotnetDISingletonDisposingPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceInjector.Configure();
            ServiceInjector.StartScope();

            var sampleService = ServiceInjector.GetService<ISampleSingletonService>();
            sampleService.Log("Very important log!");

            ServiceInjector.KillAllScopes();
        }
    }
}
