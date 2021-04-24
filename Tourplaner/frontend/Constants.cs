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
        //https://tools.runnerspace.com/gprofile.php?do=title&title_id=802&mgroup_id=45577
        public static int WalkingKcalBurnPerKm = 60;
        public static int RunningKcalBurnPerKm = 80;
        //https://captaincalculator.com/health/calorie/calories-burned-cycling-calculator/
        public static int BicycleKcalBurnPerKm = 40;

    }

}