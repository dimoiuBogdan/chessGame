using BoardGame.Pieces;

namespace BoardGame.Chess
{
    public class ChessGame : Game
    {
        public ChessGame() : base(new ChessPieceFactory())
        {

        }
    }
}
