namespace Lesson_11_Ferm_abstract_class
{
    public class CombineLogger : ILogger
    {
        private ILogger[] _loggers;

        public CombineLogger(ILogger[] loggers)
        {
            _loggers = loggers;
        }
        public void LogInfo(string message)
        {
            foreach(ILogger logger in _loggers)
            {
                logger.LogInfo(message);
            }
        }

        public void LogInfoFile(string message)
        {
            Console.WriteLine("TEST");
            foreach (ILogger logger in _loggers)
            {
                logger.LogInfo(message);
            }
        }
    }
}
