using LogSharp.Models;

namespace LogSharp.Example
{
    /// <summary>
    ///     A simple example of logs.
    /// </summary>
    public class SimpleExample
    {
        /// <summary>
        ///     The log instance.
        /// </summary>
        private readonly ILogger _logger = LoggerFactory.Create("Example");

        /* 
        The result log file should resemble this:
        2/17/2016 1:57:59 PM - [Debug-Example]-> Debug event.
        2/17/2016 1:57:59 PM - [Warning-Example]-> Warning event.
        2/17/2016 1:57:59 PM - [Error-Example]-> Error event.
        2/17/2016 1:57:59 PM - [Info-Example]-> Info event.
        2/17/2016 1:57:59 PM - [Critical-Example]-> This should be here. Five is less than six.
        2/17/2016 1:57:59 PM - [Debug-Factory.Create.LogWriteTest]-> 1
        2/17/2016 1:57:59 PM - [Debug-Factory.Create.LogWriteTest]-> 2
        2/17/2016 1:57:59 PM - [Debug-Factory.Create.LogWriteTest]-> 3              
        */

        /// <summary>
        ///     Tests the logger by writing a log to \\Logs as LogEntry-DateTime(...).txt.
        /// </summary>
        public void Test()
        {
            _logger.LogDebug("Debug event.");
            _logger.LogWarning("Warning event.");
            _logger.LogError("Error event.");
            _logger.LogInfo("Info event.");
            _logger.Log("This should not be here. Five is not greater than six.", CustomLLogLevels.Critical, 5 > 6);
            _logger.Log("This should be here. Five is less than six.", CustomLLogLevels.Critical, 5 < 6);
        }
    }
}