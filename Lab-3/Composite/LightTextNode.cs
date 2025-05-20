namespace Composite
{
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }
        public void setText(string t)
        {
            _text = t;
        }
        public override string OuterHTML => _text;
        public override string InnerHTML => _text;
    }
}
