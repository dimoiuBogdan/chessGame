using BoardGame.Pieces;

namespace BoardGame.API
{
    public interface IPieceFactory
    {
        public APiece GetInstance(int type, PieceColor color);
    }
}
