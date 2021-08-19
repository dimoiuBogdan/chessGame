using System;
using System.IO;
using System.Windows.Forms;

namespace BoardGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (StreamWriter writer = new("log.txt"))
            {
                Console.SetOut(writer);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GameForm());
            }

            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            currentAppDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);
        }

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Sorry, there was an error! {e.ExceptionObject}");
            MessageBox.Show($"Sorry, there was an error! {e.ExceptionObject}");
        }
    }
}