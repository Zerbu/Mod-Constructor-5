using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.ExportSystem.Tuning
{
    public static class FNVHasher
    {
        public static uint FNV24(string value)
        {
            if (FNV24Cache.ContainsKey(value))
            {
                return FNV24Cache[value];
            }

            var num = FNV32(value, false);
            var result = (num >> 24) ^ (num & 16777215);
            FNV24Cache.Add(value, result);
            return result;
        }

        public static uint FNV32(string value, bool highBit)
        {
            if (!highBit && FNV32Cache.ContainsKey(value))
            {
                return FNV32Cache[value];
            }

            if (highBit && FNV32HighBitCache.ContainsKey(value))
            {
                return FNV32HighBitCache[value];
            }

            var num = 2166136261;
            var bytes = Encoding.ASCII.GetBytes(value.ToLowerInvariant());
            foreach (var b in bytes)
            {
                num *= 16777619;
                num ^= b;
            }

            var result = highBit ? num | 2147483648 : num;
            var addToDictionary = highBit ? FNV32HighBitCache : FNV32Cache;
            addToDictionary.Add(value, result);
            return result;
        }

        public static ulong FNV64(string value, bool highBit)
        {
            if (!highBit && FNV64Cache.ContainsKey(value))
            {
                return FNV64Cache[value];
            }

            if (highBit && FNV64HighBitCache.ContainsKey(value))
            {
                return FNV64HighBitCache[value];
            }

            var num = 14695981039346656037;
            var bytes = Encoding.ASCII.GetBytes(value.ToLowerInvariant());
            foreach (var b in bytes)
            {
                num *= 1099511628211;
                num ^= b;
            }

            var result = highBit ? num | 9223372036854775808 : num;
            var addToDictionary = highBit ? FNV64HighBitCache : FNV64Cache;
            addToDictionary.Add(value, result);

            return result;
        }

        private static Dictionary<string, uint> FNV24Cache { get; } = new Dictionary<string, uint>();
        private static Dictionary<string, uint> FNV32Cache { get; } = new Dictionary<string, uint>();
        private static Dictionary<string, uint> FNV32HighBitCache { get; } = new Dictionary<string, uint>();
        private static Dictionary<string, ulong> FNV64Cache { get; } = new Dictionary<string, ulong>();
        private static Dictionary<string, ulong> FNV64HighBitCache { get; } = new Dictionary<string, ulong>();
    }
}
