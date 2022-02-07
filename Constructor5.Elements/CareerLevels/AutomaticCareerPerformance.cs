using System.Linq;

namespace Constructor5.Elements.CareerLevels
{
    public static class AutomaticCareerPerformance
    {
        public static int GetBasePerformance(int level)
        {
            var arr = new[] { 60, 50, 40, 30, 20, 15, 10, 8, 7, 6, 5 };
            return level >= arr.Length ? arr.Last() : arr[level - 1];
        }

        /*public static int GetIdealEmotionModifier(int level)
        {
            var arr = new[] { 10, 10, 10, 5, 5, 4, 4, 4, 3, 3, 3 };
            return level >= arr.Length ? arr.Last() : arr[level - 1];
        }*/

        public static int GetStandardEmotionModifier(int level)
        {
            var arr = new[] { 10, 10, 10, 5, 5, 4, 4, 4, 3, 3, 3 };
            return level >= arr.Length ? arr.Last() : arr[level - 1];
        }
    }
}
