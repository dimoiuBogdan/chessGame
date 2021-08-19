using BoardGame.API;
using BoardGame.Pieces;
using Microsoft.Practices.Unity;
using System.Windows.Forms;
using Unity;

namespace BoardGame
{
    public class Referee
    {
        private Context Context { get; set; }

        // 1. Declaram delegatul si evenimentul ( + clasa de EventArgs )
        public delegate void ChangedContextHandler(object sender, ChangedContextEventArgs e);
        public event ChangedContextHandler ContextChanged;

        public Referee()
        {

        }

        public void Initialize()
        {
            Context = new();

            Context.Layout = DependencyContainer.Container.Resolve<ALayout>();

            Context.Layout.Initialize();

            Context.MoveHistory = new();
        }

        public void StartWithContext(Context context)
        {
            Context = context.Clone();
            Start();
        }

        public void Start()
        {
            // 4. Transmitem parametrii
            ChangedContextEventArgs changedContextArgs = new(Context.Clone());

            // 5. Invocam metoda in cazul in care avem ascultatori ( vezi clasa inregistrata ca ascultator )
            ContextChanged?.Invoke(this, changedContextArgs);
        }

        public Context GetContext()
        {
            return Context.Clone();
        }

        public void Board_MoveProposed(object sender, MoveProposedEventArgs e)
        {
            try
            {
                if (IsValid(e.Move))
                {
                    Context.Layout.Move(e.Move);
                    Context.MoveHistory.Add(e.Move);

                    Context.ColorToMove = Context.ColorToMove == PieceColor.Black ? PieceColor.White : PieceColor.Black;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Could not validate move");
            }

            try
            {
                ChangedContextEventArgs changedContextArgs = new(Context.Clone());

                ContextChanged?.Invoke(this, changedContextArgs);
            }
            catch (System.Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Context could not be sent");
            }
        }

        private bool IsValid(Move move)
        {
            return Context.Layout[move.Source].GetAvailableMoves(move.Source, Context).Contains(move.Target);
        }

        public void Cleanup()
        {
            Context.Layout.Cleanup();
            Context.Layout = null;

            Context.MoveHistory.Clear();
            Context.MoveHistory = null;

            Context = null;
        }
    }
}

// Ce constructor se apeleaza ( in C++ cand dai return din constructor, se returneaza o clona )