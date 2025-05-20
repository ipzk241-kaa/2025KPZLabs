namespace Memento
{
    public class TextDocumentMemento
    {
        public string Content { get; }

        public TextDocumentMemento(string content)
        {
            Content = content;
        }
    }
}
