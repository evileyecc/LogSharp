namespace LogSharp.Models
{
    /// <summary>
    /// </summary>
    public class LogLevel
    {
        /// <summary>
        ///     The information
        /// </summary>
        public static readonly LogLevel Info = new LogLevel("Info");

        /// <summary>
        ///     The debug
        /// </summary>
        public static readonly LogLevel Debug = new LogLevel("Debug");

        /// <summary>
        ///     The warning
        /// </summary>
        public static readonly LogLevel Warning = new LogLevel("Warning");

        /// <summary>
        ///     The error
        /// </summary>
        public static readonly LogLevel Error = new LogLevel("Error");

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogLevel" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public LogLevel(string value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public string Value { get; }
    }
}