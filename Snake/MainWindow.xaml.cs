﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Rectangle> snake;
        int snakeSize = 32;
        int score = 0;
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
            GameCanvas.Children.Add(head);
            score = 0;

            Canvas.SetLeft(head, 100);
            Canvas.SetTop(head, 100);

            Rectangle food = CreateFood();
            GameCanvas.Children.Add(food);

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

    }
}