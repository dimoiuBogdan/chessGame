using BoardGame.API;
using Microsoft.Practices.Unity;
using System.ComponentModel;
using System.Threading;
using Unity;

namespace BoardGame
{
    public class MovePlayer
    {
        private BackgroundWorker Worker { get; set; }
        private Referee Referee { get; set; }
        private Context LoadedContext { get; set; }
        private Context RunningContext { get; set; }

        public MovePlayer(Context loadedContext, Referee referee)
        {
            LoadedContext = loadedContext;
            Referee = referee;
        }

        public void Initialize()
        {
            RunningContext = new();
            RunningContext.MoveHistory = new();
            RunningContext.Layout = DependencyContainer.Container.Resolve<ALayout>();
            RunningContext.Layout.Initialize();
        }

        public void ReplayMoves()
        {
            Cleanup();

            Initialize();

            Worker = new();
            Worker.DoWork += Worker_DoWork;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.WorkerReportsProgress = true;
            Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Worker.ReportProgress(0);

            int i = 1;
            IBoard.IsLoading = false;
            foreach (Move move in LoadedContext.MoveHistory)
            {
                Thread.Sleep(1000);

                RunningContext.Layout.Move(move);

                RunningContext.MoveHistory.Add(move);

                RunningContext.ColorToMove = RunningContext.ColorToMove == Pieces.PieceColor.Black ? Pieces.PieceColor.White : Pieces.PieceColor.Black;

                Worker.ReportProgress(i++ * 100 / LoadedContext.MoveHistory.Count);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Referee.StartWithContext(RunningContext);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IBoard.IsLoading = false;
        }

        public void Cleanup()
        {
            if (Worker != null)
            {
                if (Worker.IsBusy)
                {
                    Worker.CancelAsync();
                }
                Worker.ProgressChanged -= Worker_ProgressChanged;
                Worker.DoWork -= Worker_DoWork;
                Worker = null;
            }

            if (RunningContext != null)
            {
                RunningContext.Layout.Cleanup();
                RunningContext.Layout = null;
                RunningContext.MoveHistory = null;
                RunningContext = null;
            }
        }

    }
}