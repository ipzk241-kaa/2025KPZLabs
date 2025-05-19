namespace Bridge
{
    public interface IRenderer
    {
        void Render(string shapeName);
    }

    public class VectorRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as vectors.");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as pixels.");
        }
    }

}
