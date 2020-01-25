using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using GreenFox;

namespace _15_DrawingProject
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);
            int detail = 30;
            int size = 20;
            Width = Height = size * detail;
            CanResize = false;

            // HERE GOES THE CODE


            foxDraw.SetStrokeThicknes(2);

            for (int a = 0; a <= detail; a++)
            {
                foxDraw.SetStrokeColor(Colors.LimeGreen);
                foxDraw.DrawLine(0, a * size, a * size, detail * size);
                foxDraw.SetStrokeColor(Colors.Purple);
                foxDraw.DrawLine(detail * size, (detail - a) * size, (detail - a) * size, 0);
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
