using Composite;

namespace Iterator
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private Queue<LightNode> queue = new();

        public BreadthFirstIterator(LightNode root)
        {
            if (root != null)
                queue.Enqueue(root);
        }

        public bool HasNext() => queue.Count > 0;

        public LightNode Next()
        {
            var current = queue.Dequeue();

            if (current is LightElementNode element)
            {
                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return current;
        }
    }

}
