namespace Composite
{
    public class LightImageNode : LightElementNode
    {
        public string Src { get; }
        private readonly ILoadStrategy _strategy;
        private readonly string _loadedInfo;

        public LightImageNode(string src, ILoadStrategy strategy) : base("img")
        {
            Src = src;
            _strategy = strategy;
            _loadedInfo = _strategy.Load(src);
        }

        public override string OuterHTML => $"<{TagName} src=\"{Src}\" />";
        public string LoadInfo => _loadedInfo;
    }
}
