using System;
using System.Windows.Forms;

namespace BoardGame
{
    public interface IBoard
    {
        static bool IsLoading { get; set; }

        Action<object, MoveProposedEventArgs> MoveProposed { get; set; }

        void Initialize();

        void Referee_ContextChanged(object sender, ChangedContextEventArgs e);

        void Cleanup();

        void Reshape(int width, int v, int height);

        Control GetGraphicalControl();
    }
}
