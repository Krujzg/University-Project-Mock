using System;

namespace MockPractice.Practice
{
    public interface IService : IDisposable
    {
        string Name { get; }
        bool IsConnected { get; }
        IDisposable Connect();
        string GetContent(long identity);
    }
}