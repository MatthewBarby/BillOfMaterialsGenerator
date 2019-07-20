using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Utilities.Interfaces;

namespace Utilities
{
    /// <summary>
    /// An logging implementation using Log4net
    /// </summary>
    public class LogWrapper : ILogWrapper
    {
        private string assemblyLocation;
        private string configFileName;

        private readonly log4net.ILog log;
        public LogWrapper()
        {
            var assembly = Assembly.GetEntryAssembly();
            assemblyLocation = Path.GetDirectoryName(assembly.Location);
            configFileName = "Log4netConfig.xml";

            var repository = log4net.LogManager.CreateRepository(
                assembly, typeof(log4net.Repository.Hierarchy.Hierarchy));

            var configFile = new FileInfo($@"{assemblyLocation}\{configFileName}");

            XmlConfigurator.ConfigureAndWatch(repository, configFile);
            log = log4net.LogManager.GetLogger(this.GetType());
        }

        public void LogDebug(string message)
        {
            log.Debug(message);
        }

        public void LogInfo(string message)
        {
            log.Info(message);
        }

        public void LogWarn(string message)
        {
            log.Warn(message);
        }

        public void LogError(string message)
        {
            log.Error(message);
        }
    }
}
