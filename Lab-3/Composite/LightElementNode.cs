namespace Composite
{
    public enum DisplayType { Block, Inline }
    public enum ClosingType { Normal, SelfClosing }

    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public DisplayType Display { get; set; }
        public ClosingType Closing { get; set; }
        public List<string> CssClasses { get; set; } = new();
        public List<LightNode> Children { get; set; } = new();

        public LightElementNode(string tagName, DisplayType display = DisplayType.Block, ClosingType closing = ClosingType.Normal)
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
        }

        public override string InnerHTML => string.Join("", Children.Select(c => c.OuterHTML));

        public override string OuterHTML
        {
            get
            {
                string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
                if (Closing == ClosingType.SelfClosing)
                    return $"\n<{TagName}{classes}/>\n";
                else
                    return $"\n<{TagName}{classes}>{InnerHTML}</{TagName}>\n";
            }
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }
    }
}
