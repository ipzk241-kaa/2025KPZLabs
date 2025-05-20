namespace ChainOfResponsibility
{
    abstract class SupportHandler
    {
        protected SupportHandler Next;

        public void SetNext(SupportHandler next)
        {
            Next = next;
        }

        public abstract bool Handle(SupportRequest request);
    }
}
