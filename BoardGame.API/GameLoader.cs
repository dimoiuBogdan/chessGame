using BoardGame.API;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System.IO;
using Unity;

namespace BoardGame
{
    public class GameLoader
    {
        private string FileContent;

        public GameLoader()
        {

        }

        public Context Load(string fileName, IPieceFactory factory)
        {
            using StreamReader reader = new(File.OpenRead(fileName));

            FileContent = reader.ReadToEnd();

            return PopulateNewContext(factory);
        }

        private Context PopulateNewContext(IPieceFactory factory)
        {
            var deserializedContext = JsonConvert.DeserializeObject<AdaptedContext>(FileContent);

            Context context = new();
            context.Layout = DependencyContainer.Container.Resolve<ALayout>();
            context.MoveHistory = new();

            foreach (var piece in deserializedContext.AdaptedLayout)
            {
                context.Layout.Add(Coordinate.GetInstance(piece.Key.X, piece.Key.Y), factory.GetInstance(piece.Value.Type, piece.Value.Color));
            }

            foreach (var move in deserializedContext.AdaptedMoves)
            {
                context.MoveHistory.Add(new Move(Coordinate.GetInstance(move.Source.X, move.Source.Y), Coordinate.GetInstance(move.Target.X, move.Target.Y)));
            }

            context.ColorToMove = deserializedContext.ColorToMove;

            return context;
        }
    }
}
