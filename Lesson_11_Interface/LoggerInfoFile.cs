namespace Lesson_11_Ferm_abstract_class
{
    public class LoggerInfoFile : ILogger
    {
        public string fileFullPath;

        public LoggerInfoFile(string path)
        {
            fileFullPath = path;
        }
        public void LogInfo(string message)
        {
            //string filePath = @"Z:\I.P.Kuznetsova\GameFerm.txt";
            //string fileName = "";
            string fullFilePath = fileFullPath;
            var n = Environment.NewLine;
            FileInfo fileInfo = new FileInfo(fullFilePath);
            if (!fileInfo.Exists)
                fileInfo.Create();
            if (fileInfo.IsReadOnly)
                Console.WriteLine($"Проверьте Ваши права доступа к файлу. Отсутствуют права на изменение.{n}Результат игры не будет записан в файл");
            if (fileInfo.Exists)
                File.AppendAllText(fullFilePath, $"{DateTime.Now} : {message}{n}");
        }
    }
}
