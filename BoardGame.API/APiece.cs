using BoardGame.Pieces;
using System.Collections.Generic;
using System.Drawing;

namespace BoardGame
{
    public abstract class APiece
    {
        protected static Dictionary<PieceColor, Dictionary<int, Bitmap>> _imagesPool;

        public PieceColor Color { get; set; }
        public int Type { get; set; }

        public APiece(PieceColor color, int type)
        {
            Color = color;
            Type = type;
        }

        public abstract Bitmap GetImage();

        public abstract List<Coordinate> GetAvailableMoves(Coordinate initialCoordinates, Context context);
    }
}