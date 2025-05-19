using Composite;

namespace Flyweight
{
    public static class TreeAnalyzer
    {
        public static int CountNodes(LightNode node)
        {
            if (node is LightTextNode)
                return 1;
            if (node is LightElementNode element)
                return 1 + element.Children.Sum(child => CountNodes(child));
            return 0;
        }

        public static IEnumerable<LightNode> Children(this LightElementNode element)
        {
            var prop = typeof(LightElementNode).GetField("_children", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return prop?.GetValue(element) as List<LightNode> ?? new();
        }
    }

}
