namespace Memento
{
    public class TextEditor
    {
        private readonly TextDocument _document;
        private readonly Stack<TextDocumentMemento> _history = new();

        public TextEditor(TextDocument document)
        {
            _document = document;
        }

        public void Write(string text)
        {
            _history.Push(_document.Save());
            _document.Write(text);
        }

        public void Erase()
        {
            _history.Push(_document.Save());
            _document.Erase();
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var previous = _history.Pop();
                _document.Restore(previous);
            }
            else
            {
                Console.WriteLine("Історія змін порожня.");
            }
        }

        public void Show()
        {
            Console.WriteLine($"Документ:\n{_document.Content}\n");
        }
    }
}
