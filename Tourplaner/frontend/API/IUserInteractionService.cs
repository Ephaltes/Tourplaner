namespace frontend.CustomControls
{
    /// <summary>
    /// Interface to interact with the user
    /// </summary>
    public interface IUserInteractionService
    {
        /// <summary>
        /// Displays a save dialog
        /// </summary>
        /// <param name="filter">the options displayed in the save dialog</param>
        /// <returns></returns>
        public string ShowSaveDialog(string filter="PDF file (*.pdf)|*.pdf");

        /// <summary>
        /// Displays a file dialog
        /// </summary>
        /// <param name="filter">filetypes to be able to chose from</param>
        /// <returns></returns>
        public string[] ShowOpenFileDialog(string filter = "JSON File (*.json)|*.json");
        /// <summary>
        /// Shows an Error Messagebox
        /// </summary>
        /// <param name="message">The Error Message</param>
        /// <param name="caption">The Title of the MessageBox</param>
        public void ShowErrorMessageBox(string message, string caption = "Error");
    }
}