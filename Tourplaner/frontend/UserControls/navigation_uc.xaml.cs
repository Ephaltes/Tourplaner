using frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serilog;

namespace frontend.UserControls
{
    /// <summary>
    /// Interaction logic for navigation_uc.xaml
    /// </summary>
    public partial class navigation_uc : UserControl
    {
        public navigation_uc()
        {
            Log.Debug("Initializing Navigation_UC");
            InitializeComponent();
        }
    }
}
