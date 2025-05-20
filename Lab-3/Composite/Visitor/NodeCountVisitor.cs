using Composite;

namespace Visitor
{
    public class NodeCounterVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
            foreach (var child in element.Children)
            {
                child.Accept(this);
            }
        }

        public void VisitText(LightTextNode textNode)
        {
            TextCount++;
        }
    }
}
