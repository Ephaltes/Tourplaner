using System.Windows.Media;

namespace frontend
{
    public class Constants
    {
        public static string MaximizePath = "../icons/maximize.png";
        public static string ResizeDown = "../icons/resize_down.png";
        public static Brush BackgroundColor =(Brush) new BrushConverter().ConvertFrom("#192742");
        public static Brush SideMenuColor = (Brush)new BrushConverter().ConvertFrom("#25395f");
        public static Brush BackgroundHighlightColor = (Brush)new BrushConverter().ConvertFrom("#405985");
        public static Brush ToolTipColor = (Brush)new BrushConverter().ConvertFrom("#1950ba");
        
    }

}