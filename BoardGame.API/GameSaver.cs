using Newtonsoft.Json;
using System.IO;

namespace BoardGame
{
    public class GameSaver
    {
        private AdaptedContext PopulateAdaptedContext(Context receivedContext)
        {
            AdaptedContext adaptedContext = new();
            adaptedContext.AdaptedLayout = new();
            adaptedContext.AdaptedMoves = new();

            if (receivedContext != null && receivedContext.Layout != null)
            {
                foreach (var piece in receivedContext.Layout)
                {
                    adaptedContext.AdaptedAPiece = new AdaptedAPiece(piece.Value.Color, piece.Value.Type);
                    adaptedContext.AdaptedLayout.Add(new(new AdaptedCoordinate(piece.Key.X, piece.Key.Y), new AdaptedAPiece(piece.Value.Color, piece.Value.Type)));
                }
            }

            if (receivedContext != null && receivedContext.MoveHistory != null)
            {
                foreach (var move in receivedContext.MoveHistory)
                {
                    var newAdaptedMove = new AdaptedMove(new AdaptedCoordinate(move.Source.X, move.Source.Y), new AdaptedCoordinate(move.Target.X, move.Target.Y));
                    adaptedContext.AdaptedMoves.Add(newAdaptedMove);
                }
            }

            adaptedContext.ColorToMove = receivedContext.ColorToMove;

            return adaptedContext;
        }

        public void Save(Context context, string fileName)
        {
            var adaptedContext = PopulateAdaptedContext(context);

            string serializedContext = JsonConvert.SerializeObject(adaptedContext, Formatting.Indented);

            using StreamWriter sw = new(fileName);
            sw.Write(serializedContext);
        }
    }
}
