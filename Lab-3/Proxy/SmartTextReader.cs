namespace Proxy
{
    public class SmartTextReader
    {
        public char[][] ReadFile(string path)
        {
            var lines = File.ReadAllLines(path);
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
    }
}
