namespace State
{
    public interface IRenderState
    {
        string GetStyle();
    }
    public class NormalState : IRenderState
    {
        public string GetStyle() => "color: black;";
    }

    public class HoverState : IRenderState
    {
        public string GetStyle() => "color: blue; background-color: lightgray;";
    }

    public class ActiveState : IRenderState
    {
        public string GetStyle() => "color: white; background-color: black;";
    }

}
