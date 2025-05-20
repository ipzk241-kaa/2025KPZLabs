using Iterator;
using State;
using Visitor;
namespace Composite
{
    public delegate void EventHandler(string eventType, LightElementNode sender);
    public enum DisplayType { Block, Inline }
    public enum ClosingType { Normal, SelfClosing }

    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public DisplayType Display { get; set; }
        public ClosingType Closing { get; set; }
        public List<string> CssClasses { get; set; } = new();
        public List<LightNode> Children { get; set; } = new();
        private Dictionary<string, List<EventHandler>> _eventListeners = new();
        private IRenderState _currentState;
        public LightElementNode(string tagName, DisplayType display = DisplayType.Block, ClosingType closing = ClosingType.Normal)
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
            _currentState = new NormalState();
        }
        public void AddEventListener(string eventType, EventHandler handler)
        {
            if (!_eventListeners.ContainsKey(eventType))
                _eventListeners[eventType] = new List<EventHandler>();

            _eventListeners[eventType].Add(handler);
        }
        public void Trigger(string eventType)
        {
            string label = CssClasses.Count > 0 ? $".{CssClasses[0]}" : $"<{TagName}>";
            Console.WriteLine($" Подія \"{eventType}\" викликана на {label}.");
            if (_eventListeners.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(eventType, this);
                }
            }
        }

        public override string InnerHTML => string.Join("", Children.Select(c => c.OuterHTML));

        public override string OuterHTML => Render();

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public void SetState(IRenderState state)
        {
            _currentState = state;
        }
        protected override void OnCreated()
        {
            Console.WriteLine($"[Created] <{TagName}> element created.");
        }

        protected override void OnClassListApplied()
        {
            if (CssClasses.Any())
                Console.WriteLine($"[ClassList Applied] Classes: {string.Join(", ", CssClasses)}");
        }

        protected override void OnStylesApplied()
        {
            Console.WriteLine($"[Styles Applied] Current style: {_currentState.GetStyle()}");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"[Inserted] <{TagName}> added to DOM.");
        }
        protected override string RenderContent()
        {
            var style = _currentState.GetStyle();
            var styleAttr = !string.IsNullOrWhiteSpace(style) ? $" style=\"{style}\"" : "";

            var classAttr = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";

            var openingTag = $"\n<{TagName}{classAttr}{styleAttr}>\n";
            var content = InnerHTML;
            var closingTag = $"\n</{TagName}>\n";

            if (Closing == ClosingType.SelfClosing)
                return $"{openingTag}{content}";
            else
                return $"{openingTag}{content}{closingTag}";
        }
        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.VisitElement(this);
        }

        public ILightNodeIterator GetDepthFirstIterator()
        {
            return new DepthFirstIterator(this);
        }

        public ILightNodeIterator GetBreadthFirstIterator()
        {
            return new BreadthFirstIterator(this);
        }
    }
}
