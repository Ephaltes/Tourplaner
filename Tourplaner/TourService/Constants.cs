using System.IO;

namespace TourService
{
    public class Constants
    {
        //https://tools.runnerspace.com/gprofile.php?do=title&title_id=802&mgroup_id=45577
        public static int WalkingKcalBurnPerKm = 60;
        public static int RunningKcalBurnPerKm = 80;
        //https://captaincalculator.com/health/calorie/calories-burned-cycling-calculator/
        public static int BicycleKcalBurnPerKm = 40;

        public static string ImagePath = Directory.GetCurrentDirectory() + "/images/";
    }
}