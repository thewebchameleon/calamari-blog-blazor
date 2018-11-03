namespace CB.Blazor.Infrastructure.Configuration
{
    public class LoggingConfig
    {
        public string MinimumLogLevel { get; set; }

        public SeqConfig Seq { get; set; }

        public RollingFileConfig RollingFile { get; set; }
    }

    public class SeqConfig
    {
        public bool IsEnabled { get; set; }

        public string Endpoint { get; set; }
    }

    public class RollingFileConfig
    {
        public bool IsEnabled { get; set; }

        public string Path { get; set; }
    }

    public class ConsoleConfig
    {
        public bool IsEnabled { get; set; }
    }
}
