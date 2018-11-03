using System;

namespace CB.Blazor.Infrastructure.Logging
{
    public interface ILoggerService
    {
        void LogDebug(string debug, params object[] objects);

        void LogInformation(string info, params object[] objects);

        void LogError(Exception ex, string message, params object[] objects);

        void LogWarning(string warn, params object[] objects);
    }
}
