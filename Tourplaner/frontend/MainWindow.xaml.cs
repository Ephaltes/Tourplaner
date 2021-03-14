﻿
using System.Windows;


namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object context)
        {
            InitializeComponent();
            
            DataContext = context;
        }
    }
}
