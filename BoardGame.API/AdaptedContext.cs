using BoardGame.Pieces;
using System.Collections.Generic;

namespace BoardGame
{
    public class AdaptedContext
    {
        public List<KeyValuePair<AdaptedCoordinate, AdaptedAPiece>> AdaptedLayout;
        public List<AdaptedCoordinate> AdaptedCoordinate;
        public List<AdaptedMove> AdaptedMoves;
        public AdaptedAPiece AdaptedAPiece;
        public PieceColor ColorToMove;

        public AdaptedContext()
        {

        }
    }
}