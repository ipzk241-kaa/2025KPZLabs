namespace Adapter
{
    public class FileLoggerAdapter
    {
        private readonly FileWriter _fileWriter;

        public FileLoggerAdapter(string path)
        {
            _fileWriter = new FileWriter(path);
        }

        public void Log(string message)
        {
            _fileWriter.WriteLine("[LOG] " + message);
        }

        public void Error(string message)
        {
            _fileWriter.WriteLine("[ERROR] " + message);
        }

        public void Warn(string message)
        {
            _fileWriter.WriteLine("[WARNING] " + message);
        }
    }
}
