using System.IO;
using LogSharp;
using LogSharp.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogSharpTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class LogSharpCoreTest
    {
        /// <summary>
        ///     Test the instance creation of the <see cref="FileLogInstanceWrapper" /> by using the
        ///     <see cref="LoggerFactory.Create" /> to obtain the instance.
        /// </summary>
        [TestMethod]
        public void FactoryCreateTest()
        {
            var logger = LoggerFactory.Create("Factory.Create.Test");
            var fileLogInstanceWrapper = (FileLogInstanceWrapper) logger;
            Assert.IsNotNull(logger);
            Assert.IsTrue(fileLogInstanceWrapper.Sender == "Factory.Create.Test");
        }

        /// <summary>
        ///     Tests the default writing.
        /// </summary>
        [TestMethod]
        public void TestDefaultWriting()
        {
            var logger = LoggerFactory.Create("Factory.Create.LogWriteTest");
            logger.LogDebug("1");
            logger.LogDebug("2");
            logger.LogDebug("3");
            FileLogger.Instance.ForceDispose();
            var result = File.ReadAllLines(FileLogSettings.Default.GetPath());
            Assert.IsTrue(result.Length > 1);
        }
    }
}