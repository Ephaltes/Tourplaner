
using System.Windows;
using Serilog;


namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object context)
        {
            Log.Debug("Initializing MainWindow");
            InitializeComponent();
            DataContext = context;
        }
    }
}
