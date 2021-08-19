using BoardGame.API;
using BoardGame.Pieces;

namespace BoardGame
{
    public class ChessLayout : ALayout
    {

        public ChessLayout()
        {

        }

        public override void Initialize()
        {
            ChessPieceFactory factory = new();

            for (var i = 0; i < 8; i++)
            {
                Add(Coordinate.GetInstance(i, 6), factory.GetInstance((int)ChessPieceType.Pawn, PieceColor.White));
                Add(Coordinate.GetInstance(i, 1), factory.GetInstance((int)ChessPieceType.Pawn, PieceColor.Black));
            }

            Add(Coordinate.GetInstance(0, 0), factory.GetInstance((int)ChessPieceType.Rook, PieceColor.Black));
            Add(Coordinate.GetInstance(1, 0), factory.GetInstance((int)ChessPieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(2, 0), factory.GetInstance((int)ChessPieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(3, 0), factory.GetInstance((int)ChessPieceType.King, PieceColor.Black));
            Add(Coordinate.GetInstance(4, 0), factory.GetInstance((int)ChessPieceType.Queen, PieceColor.Black));
            Add(Coordinate.GetInstance(5, 0), factory.GetInstance((int)ChessPieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(6, 0), factory.GetInstance((int)ChessPieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(7, 0), factory.GetInstance((int)ChessPieceType.Rook, PieceColor.Black));

            Add(Coordinate.GetInstance(0, 7), factory.GetInstance((int)ChessPieceType.Rook, PieceColor.White));
            Add(Coordinate.GetInstance(1, 7), factory.GetInstance((int)ChessPieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(2, 7), factory.GetInstance((int)ChessPieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(3, 7), factory.GetInstance((int)ChessPieceType.King, PieceColor.White));
            Add(Coordinate.GetInstance(4, 7), factory.GetInstance((int)ChessPieceType.Queen, PieceColor.White));
            Add(Coordinate.GetInstance(5, 7), factory.GetInstance((int)ChessPieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(6, 7), factory.GetInstance((int)ChessPieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(7, 7), factory.GetInstance((int)ChessPieceType.Rook, PieceColor.White));
        }

        public override ChessLayout Clone()
        {
            var clone = new ChessLayout();

            foreach (var c in Keys)
            {
                clone.Add(c, this[c]);
            }

            return clone;
        }
    }
}