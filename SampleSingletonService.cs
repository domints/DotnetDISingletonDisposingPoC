using System;

namespace DotnetDISingletonDisposingPoC
{
    public class SampleSingletonService : ISampleSingletonService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Dispose()
        {
            Console.WriteLine("Yay! Singleton is being disposed!");
        }
    }
}