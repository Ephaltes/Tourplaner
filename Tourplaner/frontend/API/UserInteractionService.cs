using frontend.CustomControls;
using Microsoft.Win32;

namespace frontend.API
{
    public class UserInteractionService: IUserInteractionService
    {
        public string ShowSaveDialog(string filter="PDF file (*.pdf)|*.pdf")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            var dialog = saveFileDialog.ShowDialog();
            if (dialog == null || dialog == false)
                return "";
            return saveFileDialog.FileName;
        }

        public string[] ShowOpenFileDialog(string filter="JSON File (*.json)|*.json")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Multiselect = true;
            var dialog = openFileDialog.ShowDialog();
            if (dialog == null || dialog == false)
                return null;
            return openFileDialog.FileNames;
        }
    }
}