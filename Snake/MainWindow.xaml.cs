using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        private List<Rectangle> snake;
        int snakeSize = 32;
        int score = 0;
        int directionX = 1;
        int directionY = 0;
        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }

        private Rectangle CreateRectangle(bool isHead)
        {
            Rectangle rect  = new Rectangle
            {
                Width = snakeSize,
                Height = snakeSize,
                Fill = isHead ? Brushes.LimeGreen : Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            return rect;
        }

        private void StartGame()
        {
            GameCanvas.Children.Clear();

            snake = new List<Rectangle>();
            Rectangle head = CreateRectangle(true);
            snake.Add(head);
            GameCanvas.Children.Add(head);
            score = 0;

            Canvas.SetLeft(head, 100);
            Canvas.SetTop(head, 100);

            Rectangle food = CreateFood();
            GameCanvas.Children.Add(food);

            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(150);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private Rectangle CreateFood()
        {
            Rectangle food = new Rectangle
            {
                Width = snakeSize,
                Height = snakeSize,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            return food;
        }

        private void MoveSnake()
        {
            double newX = Canvas.GetLeft(snake[0]) + (directionX * snakeSize);
            double newY = Canvas.GetRight(snake[0]) + (directionY * snakeSize);

            Rectangle newHead = CreateRectangle(true);
            GameCanvas.Children.Add(newHead);
            Canvas.SetLeft(newHead, newX);
            Canvas.SetTop(newHead, newY);
            snake.Insert(0, newHead);

            GameCanvas.Children.Remove(snake[snake.Count - 1]);
            snake.RemoveAt(snake.Count - 1);

        }

        private void GameLoop(object sender, EventArgs e)
        {
            MoveSnake();
        }

    }
}