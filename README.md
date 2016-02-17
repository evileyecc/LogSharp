# LogSharp
A simple logger that can be copied into a project. that needs some basic log support.


Examples: (Should be placed in \\Logs as LogEntry-DataTime....txt).


```csharp
    public static class CustomLLogLevels
    {
        public static readonly LogLevel Critical = new LogLevel("Critical");
    }

    public class Example
    {
        
        private readonly ILogger _logger = LoggerFactory.Create("Example");

        public void Test()
        {
            _logger.LogDebug("1");
            _logger.LogWarning("1");
            _logger.LogError("1");
            _logger.LogInfo("1");
            _logger.Log("This should not be here.", CustomLLogLevels.Critical, 5 > 6);
            _logger.Log("This should be here.", CustomLLogLevels.Critical, 5 < 6);
        }
    }
