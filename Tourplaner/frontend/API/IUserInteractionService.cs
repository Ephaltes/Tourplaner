namespace frontend.CustomControls
{
    public interface IUserInteractionService
    {
        public string ShowSaveDialog(string filter="PDF file (*.pdf)|*.pdf");

        public string[] ShowOpenFileDialog(string filter = "JSON File (*.json)|*.json");
        public void ShowErrorMessageBox(string message, string caption = "Error");
    }
}