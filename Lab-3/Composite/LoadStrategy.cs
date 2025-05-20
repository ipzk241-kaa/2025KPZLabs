namespace Composite
{
    public interface ILoadStrategy
    {
        string Load(string path);
    }
    public class FileLoadStrategy : ILoadStrategy
    {
        public string Load(string path)
        {
            var actualPath = path.Replace("file://", "");
            if (File.Exists(actualPath))
                return $"Завантажено з файла: {actualPath}";
            else
                return $"Файл не знайдено: {actualPath}";
        }
    }
    public class NetworkLoadStrategy : ILoadStrategy
    {
        public string Load(string path)
        {
            return $"Завантажено з мережі: {path}";
        }
    }

}
