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
        private DispatcherTimer timer = new();
        
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
            if (numOfBalls >= 2789)
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
            for (int i = 0; i < numOfBalls; i++)
            {
                int x = random.Next(5, 684 - r);
                int y = random.Next(5, 411 - r);
                Ball ball = new Ball(x, y, r);
                while (!checkInitialCoordinates(ball))
                {
                    ball.X = random.Next(5, 684 - r);
                    ball.Y= random.Next(5, 411 - r);
                    if (checkInitialCoordinates(ball))
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
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Update!;
            timer.Start();
        }

        private bool checkInitialCoordinates(Ball newball)
        {
            if (_balls.Count == 0)
            {
                return true;
            }
            for (int i = 0; i < _balls.Count; i++)
            {
                if (Math.Pow(newball.X - _balls[i].X, 2) + Math.Pow(newball.Y - _balls[i].Y, 2) <= Math.Pow(newball.R + _balls[i].R, 2))
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

        private void checkEdgeCollisions(Ball ball)
        {
            if (ball.Y > 411 - ball.R || ball.changeY)
            {
                ball.Y -= 1;
                ball.changeY = true;
            }
            if (ball.Y < ball.R)
            {
                ball.Y += 1;
                ball.changeY = false;
            }
            if (!ball.changeY)
            {
                ball.Y += 1;
            }
            if (ball.changeY)
            {
                ball.Y -= 1;
            }
            if (ball.X > 684 - ball.R || ball.changeX)
            {
                ball.X -= 1;
                ball.changeX = true;
            }
            if (ball.X < ball.R)
            {
                ball.X += 1;
                ball.changeX = false;
            }
            if (!ball.changeX)
            {
                ball.X += 1;
            }
            if (ball.changeX)
            {
                ball.X -= 1;
            }
        }
        
        private void checkBallCollisions(Ball ball1, Ball ball2) //prawie działa
        {
            if (Math.Pow(ball1.X - ball2.X, 2) + Math.Pow(ball1.Y - ball2.Y, 2) <= Math.Pow(ball1.R + ball2.R, 2))
            {
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
                checkEdgeCollisions(_balls[i]);
                for (int j = 0; j < _balls.Count; j++)
                {
                    if (j != i)
                    {
                        checkBallCollisions(_balls[i], _balls[j]);
                    }
                }
                Canvas.SetLeft(MyCanvas.Children[i + 1], _balls[i].X - _balls[i].R);
                Canvas.SetTop(MyCanvas.Children[i + 1], _balls[i].Y - _balls[i].R);
            }
        }

        private void StopBalls(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void StartBalls(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}