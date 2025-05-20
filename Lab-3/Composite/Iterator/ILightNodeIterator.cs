using Composite;

namespace Iterator
{
    public interface ILightNodeIterator
    {
        bool HasNext();
        LightNode Next();
    }

}
