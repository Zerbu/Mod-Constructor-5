using System;

namespace Constructor5.Base.ExportSystem
{
    public static class CommentUtility
    {
        public static string StripComment(string str)
        {
            if (str == null)
            {
                return null;
            }

            return str.Split(new string[] { " <<<" }, StringSplitOptions.None)[0];
        }
    }
}
