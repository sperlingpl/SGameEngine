using System;
using System.Diagnostics;

namespace SGameEngine.Log
{
    public class DebugLogger : ILogger
    {
        public void Write(LogType logType, string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
    }
}