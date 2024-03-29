﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Serilog;

namespace frontend.UserControls
{
    /// <summary>
    /// Interaction logic for button_menu_uc.xaml
    /// </summary>
    public partial class button_menu_uc : UserControl
    {
        private bool _drag = false;
        private readonly ILogger _logger = Log.ForContext<button_menu_uc>();

        public button_menu_uc()
        {
            _logger.Debug("Initializing Button_Menu");
            InitializeComponent();
        }


        private void title_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _logger.Debug("Window Drag & Drop");
            Window window = Window.GetWindow(this);
            window?.DragMove();
        }
     
    }
}
