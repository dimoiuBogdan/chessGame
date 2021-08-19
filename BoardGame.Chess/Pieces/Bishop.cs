using BoardGame.Chess;
using System.Collections.Generic;

namespace BoardGame.Pieces
{
    public class Bishop : AChessPiece
    {
        public Bishop(PieceColor color) : base(color, ChessPieceType.Bishop)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, Context context)
        {
            List<Coordinate> availableMoves = new();

            if (context.ColorToMove == Color)
            {
                Coordinate c;

                // dreapta sus
                for (int i = 1; i < 7; i++)
                {
                    if (source.X + i < 0 || source.X + i > 7 || source.Y - i < 0 || source.Y - i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X + i, source.Y - i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
                // dreapta jos
                for (int i = 1; i < 7; i++)
                {
                    if (source.X + i < 0 || source.X + i > 7 || source.Y + i < 0 || source.Y + i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X + i, source.Y + i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
                // stanga sus
                for (int i = 1; i < 7; i++)
                {
                    if (source.X - i < 0 || source.X - i > 7 || source.Y - i < 0 || source.Y - i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X - i, source.Y - i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
                // stanga jos
                for (int i = 1; i < 7; i++)
                {
                    if (source.X - i < 0 || source.X - i > 7 || source.Y + i < 0 || source.Y + i > 7)
                    {
                        break;
                    }

                    c = Coordinate.GetInstance(source.X - i, source.Y + i);

                    if (context.Layout.ContainsKey(c))
                    {
                        if (context.Layout[c].Color != Color)
                        {
                            availableMoves.Add(c);
                        }
                        break;
                    }
                    availableMoves.Add(c);
                }
            }

            return availableMoves;
        }
    }
}
