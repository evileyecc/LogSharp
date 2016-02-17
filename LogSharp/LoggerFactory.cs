using LogSharp.File;
using LogSharp.Models;

namespace LogSharp
{
    /// <summary>
    ///     A logger factory.
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        ///     Creates the logger from the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <returns><<see cref="ILogger" />/returns>
        public static ILogger Create(string sender)
        {
            return new FileLogInstanceWrapper(sender);
        }
    }
}