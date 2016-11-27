using System;
using System.Windows;

namespace DiceRoller.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DiceRoller.Thrower.Thrower();
        }
    }
}