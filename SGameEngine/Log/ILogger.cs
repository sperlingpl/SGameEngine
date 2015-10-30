using System;

namespace SGameEngine.Log
{
    public interface ILogger
    {
        void Write(LogType logType, string format, params object[] args);
    }
}