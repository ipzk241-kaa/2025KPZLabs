using System.Text.RegularExpressions;

namespace Proxy
{
    public class SmartTextReaderLocker
    {
        private SmartTextReader _reader = new SmartTextReader();
        private Regex _denyPattern;

        public SmartTextReaderLocker(string denyPattern)
        {
            _denyPattern = new Regex(denyPattern, RegexOptions.IgnoreCase);
        }

        public char[][]? ReadFile(string path)
        {
            if (_denyPattern.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return null;
            }
            Console.WriteLine("Access allowed!");
            return _reader.ReadFile(path);
        }
    }
}
