using System;
using System.IO;
using LogSharp.Models;

namespace LogSharp.File
{
    /// <summary>
    ///     A singleton file log class, that optionally logs to the console as well. Please note, that the console log
    ///     operations are much slower (50x+) than the file log based writes.
    /// </summary>
    public sealed class FileLogger
    {
        /// <summary>
        ///     The lazy instance
        /// </summary>
        private static readonly Lazy<FileLogger> LazyInstance =
            new Lazy<FileLogger>(() => new FileLogger(FileLogSettings.Default));

        private readonly FileLogSettings _fileLogSettings;

        private readonly bool _isInitialized;
        private readonly TextWriter _logger;

        /// <summary>
        ///     Prevents a default instance of the <see cref="FileLogger" /> class from being created.
        /// </summary>
        public FileLogger(FileLogSettings settings)
        {
            _fileLogSettings = settings;
            _logger = TextWriter.Synchronized(new StreamWriter(settings.GetPath(), true));
            WriteLine("---------");
            WriteLine("log initialized, writing to " + settings.FileName);
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            _isInitialized = true;
        }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static FileLogger Instance => LazyInstance.Value;


        /**
         * Flushes the logger when the parent process exits. Disabling flush during 
         * execution speeds up logging ~2x. Handling process exit enables us to disable
         * flush after each log event and still not lose data at the end if the buffer
         * hasn't automatically flushed to disk.
         */

        private void OnProcessExit(object sender, EventArgs args)
        {
            _logger.Flush();
        }

        /// <summary>
        ///     Logs the message if the specified conditions are met.
        /// </summary>
        /// <param name="condition">The results will be logged only if the this condition is met.</param>
        /// <param name="message">The message.</param>
        public void Log(bool condition, string sender, LogLevel level, string message)
        {
            if (condition)
            {
                Log(level, sender, message);
            }
        }

        /// <summary>
        ///     Logs the specified severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="loggername">The loggername.</param>
        /// <param name="message">The message.</param>
        public void Log(LogLevel severity, string loggername, string message)
        {
            if (_isInitialized || _fileLogSettings.ConsoleEnabled)
            {
                WriteLine($"[{severity.Value}-{loggername}]-> {message}");
            }
        }


        /// <summary>
        ///     Writes a new line to the log file, as welll as to the console log if it is enabled in
        ///     <see cref="FileLogSettings" />.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public void WriteLine(string message)
        {
            if (_isInitialized)
            {
                _logger.WriteLine(DateTime.Now + " - " + message);
                if (_fileLogSettings.FlushTimerEnabled)
                {
                    _logger.Flush();
                }
            }
            // Warning: console is very slow, nearly 50x slower than file with 
            // auto-flush disabled
            if (_fileLogSettings.ConsoleEnabled)
            {
                Console.WriteLine(DateTime.Now + @" - " + message);
            }
        }

        /// <summary>
        ///     Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Write(string message)
        {
            if (_isInitialized)
            {
                _logger.Write(message);
                if (_fileLogSettings.FlushTimerEnabled)
                {
                    _logger.Flush();
                }
            }
            // Warning: console is very slow, nearly 50x slower than file with 
            // auto-flush disabled
            if (_fileLogSettings.ConsoleEnabled)
            {
                Console.WriteLine(DateTime.Now + @" - " + message);
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void ForceDispose()
        {
            _logger.Flush();
            _logger.Dispose();
        }
    }
}