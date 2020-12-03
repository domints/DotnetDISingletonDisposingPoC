using System;

namespace DotnetDISingletonDisposingPoC
{
    public interface ISampleSingletonService : IDisposable
    {
         void Log(string message);
    }
}