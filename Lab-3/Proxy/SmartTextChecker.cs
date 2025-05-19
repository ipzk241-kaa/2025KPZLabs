namespace Proxy
{
    public class SmartTextChecker
    {
        private SmartTextReader _reader = new SmartTextReader();

        public char[][] ReadFile(string path)
        {
            Console.WriteLine($"Відкриття файлу: {path}");
            char[][] content = _reader.ReadFile(path);
            Console.WriteLine($"Файл успішно прочитано: {path}");
            Console.WriteLine($"Рядки: {content.Length}, Символи: {content.Sum(line => line.Length)}");
            Console.WriteLine("Закриття файлу.");
            return content;
        }
    }

}
