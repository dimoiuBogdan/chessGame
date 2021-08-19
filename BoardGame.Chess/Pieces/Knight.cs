using BoardGame.Chess;
using System.Collections.Generic;

namespace BoardGame.Pieces
{
    public class Knight : AChessPiece
    {
        public Knight(PieceColor color) : base(color, ChessPieceType.Knight)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, Context context)
        {
            List<Coordinate> availableMoves = new();
            Coordinate sourceCoordinates = Coordinate.GetInstance(source.X, source.Y);

            if (context.ColorToMove == Color)
            {
                Coordinate c;

                // dreapta jos
                if (source.X + 1 >= 0 && source.X + 1 <= 7 && source.Y - 2 >= 0 && source.Y - 2 <= 7)
                {
                    c = Coordinate.GetInstance(source.X + 1, source.Y - 2);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                        {
                            availableMoves.Add(c);
                        }
                    }
                    else
                    {
                        availableMoves.Add(c);
                    }
                }
                // dreapta sus
                if (source.X + 1 >= 0 && source.X + 1 <= 7 && source.Y + 2 >= 0 && source.Y + 2 <= 7)
                {
                    c = Coordinate.GetInstance(source.X + 1, source.Y + 2);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                        {
                            availableMoves.Add(c);
                        }
                    }
                    else
                    {
                        availableMoves.Add(c);
                    }
                }
                // stanga jos
                if (source.X - 1 <= 7 && source.Y - 2 >= 0 && source.X - 1 >= 0 && source.Y - 2 <= 7)
                {
                    c = Coordinate.GetInstance(source.X - 1, source.Y - 2);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                        {
                            availableMoves.Add(c);
                        }
                    }
                    else
                    {
                        availableMoves.Add(c);
                    }
                }
                // stanga sus
                if (source.X - 1 <= 7 && source.Y + 2 >= 0 && source.X - 1 >= 0 && source.Y + 2 <= 7)
                {
                    c = Coordinate.GetInstance(source.X - 1, source.Y + 2);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                        {
                            availableMoves.Add(c);
                        }
                    }
                    else
                    {
                        availableMoves.Add(c);
                    }
                }
            }

            return availableMoves;
        }
    }
}
