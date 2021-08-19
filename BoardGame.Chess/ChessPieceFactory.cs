using BoardGame.API;
using System;

namespace BoardGame.Pieces
{
    public class ChessPieceFactory : IPieceFactory
    {
        public APiece GetInstance(int type, PieceColor color)
        {
            return type switch
            {
                (int)ChessPieceType.Queen => new Queen(color),
                (int)ChessPieceType.King => new King(color),
                (int)ChessPieceType.Rook => new Rook(color),
                (int)ChessPieceType.Knight => new Knight(color),
                (int)ChessPieceType.Bishop => new Bishop(color),
                (int)ChessPieceType.Pawn => new Pawn(color),
                _ => throw new Exception("Invalid argument exception"),
            };
        }
    }
}
