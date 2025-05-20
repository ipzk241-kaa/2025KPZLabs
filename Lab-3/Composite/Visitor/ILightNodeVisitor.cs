using Composite;

namespace Visitor
{
    public interface ILightNodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode textNode);
    }

}
