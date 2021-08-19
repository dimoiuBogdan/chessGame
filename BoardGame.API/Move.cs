namespace BoardGame
{
    public class Move
    {
        public Coordinate Source { get; set; }
        public Coordinate Target { get; set; }

        public Move(Coordinate source, Coordinate target)
        {
            Source = source;
            Target = target;
        }
    }
}
