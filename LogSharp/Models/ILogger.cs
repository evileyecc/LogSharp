namespace LogSharp.Models
{
    /// <summary>
    ///     Defines a logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        ///     Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogDebug(string message);

        /// <summary>
        ///     Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogError(string message);

        /// <summary>
        ///     Logs the information message.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInfo(string message);

        /// <summary>
        ///     Logs the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarning(string message);

        /// <summary>
        ///     Writes the specified message message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        ///     Writes the message by appending a new line.
        /// </summary>
        /// <param name="message">The message.</param>
        void WriteLine(string message);

        /// <summary>
        ///     Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="level">The level.</param>
        /// <param name="logCondition">if set to <c>true</c> [log condition].</param>
        void Log(string message, LogLevel level, bool logCondition);
    }
}