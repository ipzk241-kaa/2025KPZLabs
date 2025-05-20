namespace Memento
{
    public class TextDocument
    {
        public string Content { get; private set; }

        public TextDocument(string content = "")
        {
            Content = content;
        }

        public void Write(string text)
        {
            Content += text;
        }

        public void Erase()
        {
            Content = "";
        }

        public TextDocumentMemento Save()
        {
            return new TextDocumentMemento(Content);
        }

        public void Restore(TextDocumentMemento memento)
        {
            Content = memento.Content;
        }
    }
}
