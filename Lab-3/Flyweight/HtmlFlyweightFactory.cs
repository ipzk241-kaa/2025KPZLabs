using Composite;

namespace Flyweight
{
    public class HtmlFlyweightFactory
    {
        private readonly Dictionary<string, LightElementNode> _sharedElements = new();

        public LightElementNode GetFlyweight(string tag)
        {
            if (!_sharedElements.ContainsKey(tag))
                _sharedElements[tag] = new LightElementNode(tag);

            var baseElement = _sharedElements[tag];
            return new LightElementNode(baseElement.TagName)
            {
                CssClasses = baseElement.CssClasses,
                Display = baseElement.Display,
                Closing = baseElement.Closing
            };
        }

        public int SharedCount => _sharedElements.Count;
    }
}
