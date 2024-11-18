namespace Lesson_11_Ferm_abstract_class
{
    public class LoggerInfo : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}
