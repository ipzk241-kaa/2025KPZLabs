using Composite;

namespace Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class AddElementCommand : ICommand
    {
        private LightElementNode _parent;
        private LightNode _child;

        public AddElementCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.AddChild(_child);
        }
    }
    public class UpdateTextCommand : ICommand
    {
        private LightTextNode _textNode;
        private string _newText;

        public UpdateTextCommand(LightTextNode node, string newText)
        {
            _textNode = node;
            _newText = newText;
        }

        public void Execute()
        {
            _textNode.setText(_newText);
        }
    }
    public class AddCssClassCommand : ICommand
    {
        private LightElementNode _element;
        private string _cssClass;

        public AddCssClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public void Execute()
        {
            _element.CssClasses.Add(_cssClass);
        }
    }
}
