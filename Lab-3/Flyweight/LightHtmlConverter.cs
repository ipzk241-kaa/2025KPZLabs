using Composite;

namespace Flyweight
{
    public static class LightHtmlConverter
    {
        public static LightElementNode ConvertTextToHtml(string[] lines, HtmlFlyweightFactory factory)
        {
            var root = new LightElementNode("div");

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                LightElementNode element;

                if (line == lines.First())
                    element = factory.GetFlyweight("h1");
                else if (line.Length < 20)
                    element = factory.GetFlyweight("h2");
                else if (char.IsWhiteSpace(line[0]))
                    element = factory.GetFlyweight("blockquote");
                else
                    element = factory.GetFlyweight("p");

                element.AddChild(new LightTextNode(line.Trim()));
                root.AddChild(element);
            }

            return root;
        }
    }
}
