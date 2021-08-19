namespace BoardGame
{
    public class AdaptedMove
    {
        public AdaptedCoordinate Source { get; set; }
        public AdaptedCoordinate Target { get; set; }

        public AdaptedMove(AdaptedCoordinate source, AdaptedCoordinate target)
        {
            Source = source;
            Target = target;
        }
    }
}