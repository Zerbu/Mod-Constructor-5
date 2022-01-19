using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ElementSystem
{
    public static class GuidUtility
    {
        public static string GenerateGuid(IEnumerable<string> usedGuids)
        {
            var result = (string)null;
            var random = new Random();
            do
            {
                result = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (usedGuids.Contains(result));
            return result;
        }
    }
}
