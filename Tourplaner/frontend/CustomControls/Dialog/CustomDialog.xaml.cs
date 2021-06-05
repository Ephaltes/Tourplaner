using System.Windows;
using frontend.ViewModels;

namespace frontend.CustomControls.Dialog
{
    /// <summary>
    /// Interaction logic for CustomDialog.xaml
    /// </summary>
    public partial class CustomDialog : Window
    {
        public CustomDialog(string text)
        {
            DataContext = new CustomDialogViewModel(text);
            InitializeComponent();
        }
    }
}
