using System;
using Gtk;

namespace dblaba
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            bool flagCreateNotForced = false;
            bool flagCreateForced = false;

            foreach (var arg in args) {
                switch (arg) {
                    case "-c": case "--create":
                        flagCreateNotForced = true;
                        break;
                    case "-C": case "--create-forced":
                        flagCreateForced = true;
                        break;
                    default:
                        throw new("Unknown arguments");
                }
            }

            Database.QueryComposer.Init(flagCreateNotForced, flagCreateForced);

            // Application.Init();

            // var app = new Application("org.bd.bd", GLib.ApplicationFlags.None);
            // app.Register(GLib.Cancellable.Current);

            // var win = new MainWindow();
            // app.AddWindow(win);

            // win.Show();

            // Application.Run();
        }
    }
}
