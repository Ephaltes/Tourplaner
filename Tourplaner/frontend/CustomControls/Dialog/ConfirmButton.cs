using System.Windows.Controls;

namespace frontend.CustomControls.Dialog
{
    public class ConfirmButton : Button
    {
        public string Question { get; set; }
        
        protected override void OnClick()
        {
            if (string.IsNullOrWhiteSpace(Question))
            {
                base.OnClick();
                return;
            }
            var result = new CustomDialog(Question).ShowDialog();

            if (result != null && result == true)
                base.OnClick();
        }   
    }
}