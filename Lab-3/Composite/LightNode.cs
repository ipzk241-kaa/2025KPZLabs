namespace Composite
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        public string Render()
        {
            OnCreated();
            OnClassListApplied();
            OnStylesApplied();
            var html = RenderContent();
            OnInserted();
            return html;
        }

        protected abstract string RenderContent();
        protected virtual void OnCreated() { }
        protected virtual void OnInserted() { }
        protected virtual void OnRemoved() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }
    }

}
