using LogSharp.Models;

namespace LogSharp.File
{
    /// <summary>
    ///     A wrapper for the file log element.
    /// </summary>
    /// <seealso cref="ILogger" />
    public class FileLogInstanceWrapper : ILogger
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FileLogInstanceWrapper" /> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public FileLogInstanceWrapper(string sender)
        {
            Sender = sender;
        }

        /// <summary>
        ///     Gets the sender of this log element.
        /// </summary>
        /// <value>
        ///     The sender.
        /// </value>
        public string Sender { get; }

        /// <summary>
        ///     Logs the message as information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(string message)
        {
            FileLogger.Instance.Log(LogLevel.Info, Sender, message);
        }

        /// <summary>
        ///     Logs the message as debug.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message)
        {
            FileLogger.Instance.Log(LogLevel.Debug, Sender, message);
        }

        /// <summary>
        ///     Logs the message as a warning.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarning(string message)
        {
            FileLogger.Instance.Log(LogLevel.Warning, Sender, message);
        }

        /// <summary>
        ///     Logs the message as an error.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            FileLogger.Instance.Log(LogLevel.Error, Sender, message);
        }

        /// <summary>
        ///     Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Write(string message)
        {
            FileLogger.Instance.Write(message);
        }

        /// <summary>
        ///     Writes specified message as a appended new line.
        /// </summary>
        /// <param name="message">The message.</param>
        public void WriteLine(string message)
        {
            FileLogger.Instance.WriteLine(message);
        }

        /// <summary>
        ///     Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="logCondition">if set to <c>true</c> [log condition].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Log(string message, LogLevel level, bool logCondition = true)
        {
            if (!logCondition)
                return;
            FileLogger.Instance.Log(level, Sender, message);
        }
    }
}