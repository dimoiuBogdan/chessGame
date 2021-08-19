using BoardGame.Chess;
using System.Collections.Generic;

namespace BoardGame.Pieces
{
    public class King : AChessPiece
    {
        private bool EmptyBetweenRookAndKing = true;
        private bool isFirstMove = true;

        public King(PieceColor color) : base(color, ChessPieceType.King)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate source, Context context)
        {
            List<Coordinate> availableMoves = new();
            Coordinate sourceCoordinates = Coordinate.GetInstance(source.X, source.Y);

            if (source.X != 3)
            {
                isFirstMove = false;
            }

            if (context.ColorToMove == Color)
            {
                Coordinate c;

                // dreapta
                if (source.X + 1 >= 0 && source.Y >= 0 && source.X + 1 <= 7 && source.Y <= 7)
                {
                    c = Coordinate.GetInstance(source.X + 1, source.Y);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // stanga
                if (source.X - 1 >= 0 && source.Y >= 0 && source.X - 1 <= 7 && source.Y <= 7)
                {
                    c = Coordinate.GetInstance(source.X - 1, source.Y);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // jos
                if (source.X >= 0 && source.Y + 1 >= 0 && source.X <= 7 && source.Y + 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X, source.Y + 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // sus
                if (source.X >= 0 && source.Y - 1 >= 0 && source.X <= 7 && source.Y - 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X, source.Y - 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // dreapta sus
                if (source.X + 1 >= 0 && source.Y - 1 >= 0 && source.X + 1 <= 7 && source.Y - 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X + 1, source.Y - 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // dreapta jos
                if (source.X + 1 >= 0 && source.Y + 1 >= 0 && source.X + 1 <= 7 && source.Y + 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X + 1, source.Y + 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // stanga sus
                if (source.X - 1 >= 0 && source.Y - 1 >= 0 && source.X - 1 <= 7 && source.Y - 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X - 1, source.Y - 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // stanga jos
                if (source.X - 1 >= 0 && source.Y + 1 >= 0 && source.X - 1 <= 7 && source.Y + 1 <= 7)
                {
                    c = Coordinate.GetInstance(source.X - 1, source.Y + 1);

                    if (context.Layout.ContainsKey(c) && context.Layout[c].Color != context.Layout[sourceCoordinates].Color)
                    {
                        availableMoves.Add(c);
                    }
                    else
                    {
                        if (!context.Layout.ContainsKey(c))
                        {
                            availableMoves.Add(c);
                        }
                    }
                }
                // rocada mica
                if (source.X - 3 >= 0 && source.Y >= 0 && source.X - 3 <= 7 && source.Y <= 7)
                {
                    EmptyBetweenRookAndKing = true;

                    for (int i = 1; i < 3; i++)
                    {
                        c = Coordinate.GetInstance(source.X - i, source.Y);
                        if (context.Layout.ContainsKey(c) && context.Layout[c] != null)
                        {
                            EmptyBetweenRookAndKing = false;
                            break;
                        }
                    }

                    Coordinate rookPosition = Coordinate.GetInstance(source.X - 3, source.Y);

                    if (EmptyBetweenRookAndKing && isFirstMove && (context.Layout.ContainsKey(rookPosition)
                        && context.Layout[rookPosition].Color == context.Layout[sourceCoordinates].Color
                        && context.Layout[rookPosition] != null && context.Layout[rookPosition].Type == (int)ChessPieceType.Rook))
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X - 2, source.Y));
                    }
                }
                // rocada mica
                if (source.X + 4 >= 0 && source.Y >= 0 && source.X + 4 <= 7 && source.Y <= 7)
                {
                    EmptyBetweenRookAndKing = true;

                    for (int i = 1; i <= 3; i++)
                    {
                        c = Coordinate.GetInstance(source.X + i, source.Y);

                        if (context.Layout.ContainsKey(c) && context.Layout[c] != null)
                        {
                            EmptyBetweenRookAndKing = false;
                            break;
                        }
                    }

                    Coordinate rookPosition = Coordinate.GetInstance(source.X + 4, source.Y);

                    if (EmptyBetweenRookAndKing && isFirstMove && context.Layout.ContainsKey(rookPosition) &&
                        context.Layout[rookPosition].Color == context.Layout[sourceCoordinates].Color
                        && context.Layout[rookPosition] != null && context.Layout[rookPosition].Type == (int)ChessPieceType.Rook)
                    {
                        availableMoves.Add(Coordinate.GetInstance(source.X + 2, source.Y));
                    }
                }
            }

            return availableMoves;
        }
    }
}
