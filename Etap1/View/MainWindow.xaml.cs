using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Model;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<Ball> _balls = new();
        private DispatcherTimer _timer = new();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateBalls(object sender, RoutedEventArgs e)
        {
            int numOfBalls;
            try
            {
                numOfBalls = Int32.Parse(NumberOfBalls.Text);
            }
            catch (FormatException)
            {
                numOfBalls = 3;
                NumberOfBalls.Text = "3";
            }
            Random random = new Random();
            List<Brush> colors = new List<Brush>
            {
                Brushes.Blue,
                Brushes.Red,
                Brushes.Green,
                Brushes.Yellow,
                Brushes.Purple,
                Brushes.Orange,
                Brushes.Brown,
                Brushes.Black
            };
            int size = colors.Count;
            int r = random.Next(10, 21);
            if (MyCanvas.ActualHeight * MyCanvas.ActualWidth < numOfBalls * r * r * 4) //ile maksymalnie moze byc na planszy
            {
                numOfBalls = 3;
                NumberOfBalls.Text = "3";
            }
            for (int i = 0; i < numOfBalls; i++)
            {
                int x = random.Next(5, (int)MyCanvas.ActualWidth - r);
                int y = random.Next(5, (int)MyCanvas.ActualHeight - r);
                Ball ball = new Ball(x, y, r);
                while (!CheckInitialCoordinates(ball))
                {
                    ball.X = random.Next(5, (int)MyCanvas.ActualWidth - r);
                    ball.Y= random.Next(5, (int)MyCanvas.ActualHeight - r);
                    if (CheckInitialCoordinates(ball))
                    {
                        break;
                    }
                }
                Ellipse ellipse = new Ellipse
                {
                    Width = 2 * r,
                    Height = 2 * r,
                    Fill = colors[i % size],
                };
                _balls.Add(ball);
                Canvas.SetLeft(ellipse, x - _balls[i].R);
                Canvas.SetTop(ellipse, y - _balls[i].R);
                MyCanvas.Children.Add(ellipse);
            }
            Button.IsEnabled = false;
            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Tick += Update!;
            _timer.Start();
        }

        private bool CheckInitialCoordinates(Ball newball)
        {
            if (_balls.Count == 0)
            {
                return true;
            }
            for (int i = 0; i < _balls.Count; i++)
            {
                if (((newball.X - _balls[i].X) * (newball.X - _balls[i].X))
                    + ((newball.Y - _balls[i].Y) * (newball.Y - _balls[i].Y))
                    <= (newball.R + _balls[i].R) * (newball.R + _balls[i].R))
                {
                    return false;
                }
            }
            return true;
        }
        
        private void ResetBalls(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MyCanvas.Children.Count; i++)
            {
                if (MyCanvas.Children[i] is Ellipse)
                {
                    MyCanvas.Children.RemoveAt(i);
                    i--;
                }
            }
            _balls.Clear();
            Button.IsEnabled = true;
        }

        private void CheckEdgeCollisions(Ball ball)
        {
            if (ball.Y > MyCanvas.ActualHeight - ball.R || ball.changeY)
            {
                ball.Y -= ball.velY;
                ball.changeY = true;
            }
            if (ball.Y < ball.R)
            {
                ball.Y += ball.velY;
                ball.changeY = false;
            }
            if (!ball.changeY)
            {
                ball.Y += ball.velY;
            }
            if (ball.changeY)
            {
                ball.Y -= ball.velY;
            }
            if (ball.X > MyCanvas.ActualWidth - ball.R || ball.changeX)
            {
                ball.X -= ball.velX;
                ball.changeX = true;
            }
            if (ball.X < ball.R)
            {
                ball.X += ball.velX;
                ball.changeX = false;
            }
            if (!ball.changeX)
            {
                ball.X += ball.velX;
            }
            if (ball.changeX)
            {
                ball.X -= ball.velX;
            }
        }
        
        private void CheckBallCollisions(Ball ball1, Ball ball2)
        {
            if (((ball1.X - ball2.X) * (ball1.X - ball2.X)) + ((ball1.Y - ball2.Y) * (ball1.Y - ball2.Y)) <= ((ball1.R + ball2.R) * (ball1.R + ball2.R)))
            {
                double fi = Math.Atan(Math.Abs(ball1.Y - ball2.Y) / Math.Abs(ball1.X - ball2.X));
                double v1 = Math.Sqrt((ball1.velY * ball1.velY) + (ball1.velX * ball1.velX));
                double v2 = Math.Sqrt((ball2.velY * ball2.velY) + (ball2.velX * ball2.velX));
                double alpha = Math.Acos(ball1.velY / v1);
                double beta = Math.Acos(ball2.velY / v2);
                ball1.velX = v2 * Math.Cos(beta - fi) * Math.Cos(fi) + (v1 * Math.Sin(alpha - fi) * Math.Cos(fi + Math.PI / 2));
                ball1.velY = v2 * Math.Cos(beta - fi) * Math.Sin(fi) + (v1 * Math.Sin(alpha - fi) * Math.Sin(fi + Math.PI / 2));
                ball2.velX = v1 * Math.Cos(alpha - fi) * Math.Cos(fi) + (v2 * Math.Sin(beta - fi) * Math.Cos(fi + Math.PI / 2));
                ball2.velY = v1 * Math.Cos(alpha - fi) * Math.Sin(fi) + (v2 * Math.Sin(beta - fi) * Math.Sin(fi + Math.PI / 2));
                ball1.changeX = !ball1.changeX;
                ball1.changeY = !ball1.changeY;
                ball2.changeX = !ball2.changeX;
                ball2.changeY = !ball2.changeY;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                CheckEdgeCollisions(_balls[i]);
                for (int j = i + 1; j < _balls.Count; j++)
                {
                    CheckBallCollisions(_balls[i], _balls[j]);
                }
                Canvas.SetLeft(MyCanvas.Children[i + 1], _balls[i].X - _balls[i].R);
                Canvas.SetTop(MyCanvas.Children[i + 1], _balls[i].Y - _balls[i].R);
            }
        }

        private void StopBalls(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void StartBalls(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }
    }
}