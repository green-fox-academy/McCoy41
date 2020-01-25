using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using GreenFox;

namespace _15_DrawingProject
{
    public class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);
            int detail = 40;
            int size = 15;
            Width = Height = detail * size;
            CanResize = false;

            // HERE GOES THE CODE

            foxDraw.SetStrokeThicknes(2);
            foxDraw.SetStrokeColor(Colors.LimeGreen);

            for (int a = 0; a <= detail/2; a++)
            {
                foxDraw.DrawLine((detail*size/2) - (a*size), detail*size/2, detail*size/2, a*size );
                foxDraw.DrawLine((detail*size/2) - (a*size), detail*size/2, detail*size/2, detail*size - a*size );
                foxDraw.DrawLine((detail * size / 2) + (a * size), detail * size / 2, detail * size / 2, a * size);
                foxDraw.DrawLine((detail * size / 2) + (a * size), detail * size / 2, detail * size / 2, detail * size - a * size);
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

