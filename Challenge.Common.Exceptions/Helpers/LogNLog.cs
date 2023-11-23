using NLog;

namespace Challenge.Common.Exceptions.Helpers
{
    public class LogNLog : ILog
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public LogNLog()
        {
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }
        public void Debug(string message, Exception e)
        {
            logger.Debug(e, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
        public void Error(string message, Exception e)
        {
            logger.Error(e, message);
        }


    }
}
