using BoardGame.Pieces;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace BoardGame.Chess
{
    public abstract class AChessPiece : APiece
    {
        private static readonly Bitmap chessPiecesImage = new(Assembly.GetExecutingAssembly()
                  .GetManifestResourceStream("BoardGame.Chess.Resources.ChessPiecesArray.png"));

        public AChessPiece(PieceColor color, ChessPieceType type) : base(color, (int)type)
        {

        }

        public override Bitmap GetImage()
        {
            if (_imagesPool == null)
            {
                _imagesPool = new Dictionary<PieceColor, Dictionary<int, Bitmap>>();
            }

            if (!_imagesPool.ContainsKey(Color))
            {
                _imagesPool.Add(Color, new Dictionary<int, Bitmap>());
            }

            if (!_imagesPool[Color].ContainsKey(Type))
            {
                _imagesPool[Color].Add(Type, chessPiecesImage.Clone(new Rectangle(Type * 60, Color == 0 ? 0 : 60, 60, 60), chessPiecesImage.PixelFormat));
            }

            return _imagesPool[Color][Type];
        }

    }
}
