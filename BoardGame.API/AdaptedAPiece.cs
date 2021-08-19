using BoardGame.Pieces;

namespace BoardGame
{
    public class AdaptedAPiece
    {
        public PieceColor Color { get; set; }
        public int Type { get; set; }

        public AdaptedAPiece(PieceColor color, int type)
        {
            Color = color;
            Type = type;
        }
    }
}