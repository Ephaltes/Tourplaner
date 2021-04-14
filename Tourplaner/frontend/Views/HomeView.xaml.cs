using System.Windows.Controls;
using Serilog;

namespace frontend.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            Log.Debug("Initializing Home");
            InitializeComponent();
        }
    }
}