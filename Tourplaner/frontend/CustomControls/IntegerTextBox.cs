using System;
using System.Linq;
using System.Windows.Controls;

namespace frontend.CustomControls
{
    public class IntegerTextBox : TextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            Text = new String(Text.Where(c => Char.IsDigit(c)).ToArray());
            this.SelectionStart = Text.Length;

        }
    }
}