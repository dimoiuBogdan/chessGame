using System;

namespace BoardGame
{
    public class ChangedContextEventArgs : EventArgs
    {
        // 3. Declaram parametrii transportati
        public Context Context { get; set; }

        public ChangedContextEventArgs(Context context)
        {
            Context = context;
        }
    }
}
