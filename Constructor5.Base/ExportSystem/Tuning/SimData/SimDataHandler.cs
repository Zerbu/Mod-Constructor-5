using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem.Tuning.SimData
{
    public class SimDataHandler
    {
        public SimDataHandler(string templateFile)
        {
            using (var stream = File.Open(templateFile, FileMode.Open))
            {
                stream.CopyTo(Stream);
            }
        }

        public Stream Stream { get; } = new MemoryStream();

        public void Write(int position, float value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void Write(int position, long value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void Write(int position, int value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void Write(int position, uint value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void Write(int position, ulong value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void Write(int position, bool value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        public void WriteBytes(int position, byte[] value)
        {
            Stream.Position = position;
            Stream.Write(value, 0, value.Length);
        }

        public void WriteText(int position, TunableBasic tunable)
        {
            if (tunable.Value == null)
            {
                return;
            }

            WriteText(position, tunable.Value);
        }

        public void WriteText(int position, string str)
        {
            uint intValue = uint.Parse(str.Replace("0x", ""), NumberStyles.HexNumber);
            WriteBytes(position, BitConverter.GetBytes(intValue));
        }

        public void WriteText(int position, uint key) => WriteBytes(position, BitConverter.GetBytes(key));

        public void WriteTGI(int position, TunableBasic tunable, Element elementForErrorMessage)
        {
            if (tunable.Value == null)
            {
                return;
            }

            WriteTGI(position, tunable.Value, elementForErrorMessage);
        }

        public void WriteTGI(int position, string str, Element elementForErrorMessage)
        {
            if (string.IsNullOrEmpty(str) || !str.Contains(":"))
            {
                return;
            }

            var splitKey = str.Split(':');

            if (splitKey.Length != 3)
            {
                return;
            }

            var instance = splitKey[2];

            var type = splitKey[0];
            if (string.Equals(type, "2F7D0004", StringComparison.OrdinalIgnoreCase))
            {
                type = "00B2D882";
            }

            var group = splitKey[1];

            var instanceKeyValid = ulong.TryParse(instance, NumberStyles.HexNumber, null, out var instanceKey);
            var typeKeyValid = uint.TryParse(type, NumberStyles.HexNumber, null, out var typeKey);
            var groupKeyValid = uint.TryParse(group, NumberStyles.HexNumber, null, out var groupKey);

            if (!instanceKeyValid || !typeKeyValid || !groupKeyValid)
            {
                Exporter.Current.AddError(elementForErrorMessage, "UserErrorTGIFailed");
                return;
            }

            WriteBytes(position, BitConverter.GetBytes(instanceKey));
            WriteBytes(position + 8, BitConverter.GetBytes(typeKey));
            WriteBytes(position + 12, BitConverter.GetBytes(groupKey));
        }

        public void WriteList(int startPosition, IEnumerable<ulong> items, int maxSize, bool zerofillExtra, int extraSpace = 0)
        {
            var arr = items.ToList();
            if (arr.Count > maxSize)
            {
                throw new Exception("List exceeds the maximum amount allowed by the SimData");
            }

            var position = startPosition;

            var num = 0;

            foreach (var item in arr)
            {
                Write(position, item);
                position += 8 + extraSpace;
                num++;
            }

            if (!zerofillExtra || items.Count() == 1)
            {
                return;
            }

            for (var i = num; i < maxSize; i++)
            {
                Write(position, 0);
                position += 8 + extraSpace;
            }
        }

        /*public void WriteReferenceList(int position, Component compo, int max, int extraSpace = 0)
        {
            var simDataList = new List<ulong>();

            foreach (var objective in compo.GetCollection("Values").GetAllCompos(true))
            {
                foreach (var exportString in RefPlug.GetExportStrings(objective.GetObject("Value")))
                {
                    simDataList.Add(ulong.TryParse(exportString, out var exportId) ? exportId : 0);
                }
            }

            WriteList(position, simDataList, max, true, extraSpace);
        }*/
    }
}
