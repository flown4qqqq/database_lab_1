using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using dblaba.ViewModels;
using dblaba.Views;

namespace dblaba {
    public partial class App : Application
    {
        public static MainWindowViewModel TopWindow = new MainWindowViewModel();
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = TopWindow
                };

                {
                    var args = desktop.Args!;

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
                }
            }

            base.OnFrameworkInitializationCompleted();
        }
    }

}
