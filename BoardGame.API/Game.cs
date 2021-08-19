using BoardGame.API;

namespace BoardGame
{
    public class Game
    {
        public IBoard Board { get; private set; }
        public Referee Referee { get; private set; }
        public IPieceFactory Factory { get; set; }

        public Game()
        {

        }

        public Game(IPieceFactory factory)
        {
            Factory = factory;
        }

        public void Initialize(IBoard board)
        {
            Board = board;
            Referee = new();

            Board.Initialize();
            Referee.Initialize();

            Board.MoveProposed += Referee.Board_MoveProposed;
            // 2. Inregistram ca ascultator Board ( care actioneaza cu Referee_ContextChanged) la Referee.ContextChanged
            Referee.ContextChanged += Board.Referee_ContextChanged;
            // Cand se declanseaza ContextChanged.Invoke() se declanseaza si metoda inregistrata ca ascultator
        }

        public void Start()
        {
            Referee?.Start();
        }

        public void Save(string fileName)
        {
            GameSaver gameSaver = new();
            gameSaver.Save(Referee.GetContext(), fileName);
        }

        public void Load(string fileName)
        {
            GameLoader gameLoader = new();
            Context deserializedContext = gameLoader.Load(fileName, Factory);

            Referee.StartWithContext(deserializedContext);
        }

        public void Replay(string fileName)
        {
            GameLoader gameLoader = new();
            Context deserializedContext = gameLoader.Load(fileName, Factory);
            MovePlayer movePlayer = new(deserializedContext, Referee);

            movePlayer.ReplayMoves();
        }

        public void Cleanup()
        {
            Referee.ContextChanged -= Board.Referee_ContextChanged;
            Board.MoveProposed -= Referee.Board_MoveProposed;

            Referee.Cleanup();
            Board.Cleanup();

            Referee = null;
            Board = null;
        }
    }
}
