using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGame
{
    public class Board : Panel, IBoard
    {
        private const int Border = 3;
        private readonly Pen borderPen = new(Color.Gold, 5);
        public delegate void MoveProposedHandler(object sender, MoveProposedEventArgs e);
        public Action<object, MoveProposedEventArgs> MoveProposed { get; set; }
        public Context Context { get; set; }

        public int CellSize { get; set; }
        public Coordinate InitialCoordinate;
        public Coordinate TargetCoordinate;
        public Coordinate MouseOverCoordinate;

        public List<Coordinate> AvailableMoves { get; set; }

        public Board()
        {

        }

        public void Initialize()
        {
            MouseMove += Board_MouseMove;
            MouseDown += Board_MouseDown;
            MouseUp += Board_MouseUp;

            DoubleBuffered = true;
        }

        public void Referee_ContextChanged(object sender, ChangedContextEventArgs e)
        {
            try
            {
                // 6. Ne folosim de datele transportate
                Context = e.Context;

                Refresh();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show($"{ex.Message} in board");
            }
        }

        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            if (Context == null || Context.Layout == null)
            {
                return;
            }

            var coordinateY = e.Y / CellSize;
            var coordinateX = e.X / CellSize;

            Cursor = Cursors.Default;

            if ((coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0))
            {
                TargetCoordinate = Coordinate.GetInstance(coordinateX, coordinateY);

                if (InitialCoordinate != null && InitialCoordinate != MouseOverCoordinate)
                {
                    Move move = new(InitialCoordinate, TargetCoordinate);

                    MoveProposedEventArgs moveProposedArgs = new(move);

                    AvailableMoves = null;

                    MoveProposed?.Invoke(this, moveProposedArgs);
                }
            }

            InitialCoordinate = null;
            TargetCoordinate = null;

            Refresh();
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            if (Context == null || Context.Layout == null)
            {
                return;
            }

            var coordinateX = e.X / CellSize;
            var coordinateY = e.Y / CellSize;

            if (!IBoard.IsLoading && coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0 && e.Button == MouseButtons.Left)
            {
                if (Context.Layout.ContainsKey(Coordinate.GetInstance(coordinateX, coordinateY)))
                {
                    InitialCoordinate = Coordinate.GetInstance(coordinateX, coordinateY);

                    if (Context.Layout[InitialCoordinate].Color == Context.ColorToMove)
                    {
                        Cursor = new Cursor(new Bitmap(Context.Layout[InitialCoordinate].GetImage(), CellSize, CellSize).GetHicon());
                    }

                    Refresh();
                }
            }
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinateX = e.X / CellSize;
            var coordinateY = e.Y / CellSize;

            if ((coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0) &&
                (coordinateX != MouseOverCoordinate?.X || coordinateY != MouseOverCoordinate?.Y))
            {
                MouseOverCoordinate = Coordinate.GetInstance(coordinateX, coordinateY);

                if (Context != null && Context.Layout != null)
                {
                    if (Cursor == Cursors.Default)
                    {
                        if (Context.Layout.ContainsKey(MouseOverCoordinate))
                        {
                            AvailableMoves = Context.Layout[MouseOverCoordinate].GetAvailableMoves(MouseOverCoordinate, Context);
                        }
                        else
                        {
                            AvailableMoves = null;
                        }
                    }

                }
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                DrawBoard(e.Graphics);
                DrawPieces(e.Graphics);
                DrawAvailableMoves(e.Graphics);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void DrawBoard(Graphics g)
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    g.FillRectangle((row + col) % 2 == 0 ? Brushes.White : Brushes.Brown, row * CellSize, col * CellSize, CellSize, CellSize);
                }
            }
        }

        public void DrawPieces(Graphics g)
        {
            if (Context == null || Context.Layout == null)
            {
                return;
            }

            foreach (var coordinate in Context.Layout.Keys)
            {
                g.DrawImage(Context.Layout[coordinate].GetImage(), coordinate.X * CellSize, coordinate.Y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawAvailableMoves(Graphics g)
        {
            if (AvailableMoves != null && !IBoard.IsLoading)
            {
                foreach (var availableMove in AvailableMoves)
                {
                    g.DrawRectangle(borderPen, availableMove.X * CellSize, availableMove.Y * CellSize, CellSize, CellSize);
                }
            }
        }

        public void Reshape(int parentWidth, int parentHeight, int menuStripHeight)
        {
            bool widthIsSmaller = parentWidth <= parentHeight - menuStripHeight;

            var boardSize = widthIsSmaller ? parentWidth - 3 * Border : parentHeight - menuStripHeight / 3 - 6 * Border;

            CellSize = boardSize / 8;

            SetBounds(widthIsSmaller ? 0 : (parentWidth - parentHeight) / 2 + 3 * Border,
                      widthIsSmaller ? menuStripHeight + (parentHeight - parentWidth) / 2 - Border : menuStripHeight + Border,
                      boardSize,
                      boardSize);

            Refresh();
        }


        public void Cleanup()
        {
            if (Context != null && Context.Layout != null)
            {
                Context.Layout.Clear();
                Context.Layout = null;
                Context = null;
            }
        }

        public Control GetGraphicalControl()
        {
            return this;
        }
    }
}