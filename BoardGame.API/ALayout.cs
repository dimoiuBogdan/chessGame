using System.Collections.Generic;

namespace BoardGame.API
{
    public abstract class ALayout : Dictionary<Coordinate, APiece>
    {
        public abstract void Initialize();

        public abstract ALayout Clone();

        public void Move(Move move)
        {
            Remove(move.Target);

            Add(move.Target, this[move.Source]);

            Remove(move.Source);
        }

        public void Cleanup()
        {
            Clear();
        }
    }
}
