using frontend.CustomControls;
using Microsoft.Win32;

namespace frontend.API
{
    public class UserInteractionService: IUserInteractionService
    {
        public string ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
            var dialog = saveFileDialog.ShowDialog();
            if (dialog == null || dialog == false)
                return "";
            return saveFileDialog.FileName;
        }
    }
}