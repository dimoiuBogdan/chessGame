using BoardGame.API;
using BoardGame.Pieces;
using System.Collections.Generic;

namespace BoardGame
{
    public class Context
    {
        public ALayout Layout { get; set; }
        public List<Move> MoveHistory { get; set; }
        public PieceColor ColorToMove = PieceColor.White;

        public Context()
        {

        }

        public Context Clone()
        {
            var clone = new Context
            {
                Layout = Layout.Clone(),
                ColorToMove = ColorToMove,
                MoveHistory = MoveHistory
            };

            return clone;
        }
    }
}