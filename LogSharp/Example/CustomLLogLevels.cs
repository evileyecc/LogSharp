using LogSharp.Models;

namespace LogSharp.Example
{
    /// <summary>
    ///     Defines custom log levels.
    /// </summary>
    public static class CustomLLogLevels
    {
        /// <summary>
        ///     The event logged is of critical importance.
        /// </summary>
        public static readonly LogLevel Critical = new LogLevel("Critical");
    }
}