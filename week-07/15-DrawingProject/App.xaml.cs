using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace _15_DrawingProject
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Last enabled "desktop.MainWindow" will be displayed

                desktop.MainWindow = new MainWindow();
                desktop.MainWindow = new Window1();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
