using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Collections.Generic;
using System.Linq;

namespace GreenFox
{
    public class FoxDraw
    {
        private Canvas Canvas { get; set; }
        private SolidColorBrush LineColor { get; set; } = new SolidColorBrush(Colors.Black);
        private SolidColorBrush ShapeColor { get; set; } = new SolidColorBrush(Colors.DarkGreen);

        private int StrokeThickness { get; set; } = 1;

        public FoxDraw(Canvas canvas)
        {
            Canvas = canvas;
        }

        public void SetBackgroundColor(Color color)
        {
            Canvas.Background = new SolidColorBrush(color);
        }

        public void SetStrokeThicknes(int thickness)
        {
            StrokeThickness = thickness;
        }

        public void SetStrokeColor(Color color)
        {
            LineColor = new SolidColorBrush(color);
        }

        public void SetFillColor(Color color)
        {
            ShapeColor = new SolidColorBrush(color);
        }

        public void DrawEllipse(double x, double y, double width, double height)
        {
            var ellipse = new Ellipse()
            {
                Stroke = LineColor,
                StrokeThickness = StrokeThickness,
                Fill = ShapeColor,
                Width = width,
                Height = height
            };

            Canvas.Children.Add(ellipse);
            SetPosition(ellipse, x, y);
        }

        public void DrawLine(Point start, Point end)
        {
            var line = new Line()
            {
                Stroke = LineColor,
                StrokeThickness = StrokeThickness,
                StartPoint = start,
                EndPoint = end
            };

            Canvas.Children.Add(line);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(new Point(x1, y1), new Point(x2, y2));
        }

        public void DrawPolygon(IEnumerable<Point> points)
        {
            var polygon = new Polygon()
            {
                Stroke = LineColor,
                StrokeThickness = StrokeThickness,
                Fill = ShapeColor,
                Points = points.ToList()
            };

            Canvas.Children.Add(polygon);
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            var rectangle = new Rectangle()
            {
                Stroke = LineColor,
                StrokeThickness = StrokeThickness,
                Fill = ShapeColor,
                Width = width,
                Height = height
            };

            Canvas.Children.Add(rectangle);
            SetPosition(rectangle, x, y);
        }

        public void AddImage(Image image, double x, double y)
        {
            Canvas.Children.Add(image);
            SetPosition(image, x, y);
        }

        public void SetPosition(AvaloniaObject shape, double x, double y)
        {
            Canvas.SetLeft(shape, x);
            Canvas.SetTop(shape, y);
        }
    }
}