using System;
using System.IO;

namespace LogSharp.File
{
    /// <summary>
    ///     A log settings class that defines things such as the path, file name, etc.
    /// </summary>
    public class FileLogSettings
    {
        /// <summary>
        ///     Gets the default.
        /// </summary>
        /// <value>
        ///     The default.
        /// </value>
        public static readonly FileLogSettings Default = new FileLogSettings
        {
            Directory = AppDomain.CurrentDomain.BaseDirectory + "\\Logs",
            FileName = $"LogEntry{DateTime.Now.ToLongDateString()}.txt",
            ConsoleEnabled = false,
            FlushTimerEnabled = true,
            FlushInterval = 1000
        };

        private string _path = "none";

        /// <summary>
        ///     Gets or sets the directory.
        /// </summary>
        /// <value>
        ///     The directory.
        /// </value>
        public string Directory { get; set; }

        /// <summary>
        ///     Gets or sets the name of the file.
        /// </summary>
        /// <value>
        ///     The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [console enabled].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [console enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool ConsoleEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the flush interval.
        /// </summary>
        /// <value>
        ///     The flush interval.
        /// </value>
        public int FlushInterval { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [flush timer enabled].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [flush timer enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool FlushTimerEnabled { get; set; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            if (_path != "none") return _path;

            if (!System.IO.Directory.Exists(Directory))
            {
                System.IO.Directory.CreateDirectory(Directory);
            }
            _path = Path.Combine(Directory, FileName);
            return _path;
        }
    }
}