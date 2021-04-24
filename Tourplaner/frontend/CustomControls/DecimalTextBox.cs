using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace frontend.CustomControls
{
    public class DecimalTextBox : TextBox
    {
        private Regex r = new Regex(@"^-{0,1}\d+["+ CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + @"]{0,1}\d*$");

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);

            string newText = Text.Replace(" ", "") + e.Text;

            if (!r.Match(newText).Success)
            {
                e.Handled = true;
            }

        }

    }
}