using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem.Tuning.SimData
{
    public class SimDataBuilder
    {
        public SimDataBuilder()
        {
            Stream = new MemoryStream();
            Writer = new BinaryWriter(Stream);
        }

        public MemoryStream Stream { get; }

        public BinaryWriter Writer { get; }

        public void BuildHeader(int tableHeaderOffset, int numTables, int schemaOffset, int numSchemas)
        {
            Writer.Write('D');
            Writer.Write('A');
            Writer.Write('T');
            Writer.Write('A');

            Writer.Write(0x101); // version
            Writer.Write(tableHeaderOffset);
            Writer.Write(numTables);
            Writer.Write(schemaOffset);
            Writer.Write(numSchemas);
            Writer.Write(0);
            Writer.Write(0); // undocumented
        }

        public void BuildTableInfo(int nameOffset, uint nameHash, int schemaOffset, int dataType, int rowSize, int rowOffset, int rowCount)
        {
            Writer.Write(nameOffset);
            Writer.Write(nameHash);
            Writer.Write(schemaOffset);
            Writer.Write(dataType);
            Writer.Write(rowSize);
            Writer.Write(rowOffset);
            Writer.Write(rowCount);
        }

        public void BuildTableDataBase(int dataOffset, int count)
        {
            Writer.Write(dataOffset);
            Writer.Write(count);
        }

        public void WriteResourceKey(uint type, uint group, ulong instance)
        {
            Writer.Write(instance);
            Writer.Write(type);
            Writer.Write(group);
        }

        public void WriteResourceKey(string value)
        {
            var splitKey = value.Split(':');

            var instance = splitKey[2];

            var type = splitKey[0];
            if (type == "2F7D0004")
            {
                type = "00B2D882";
            }

            var group = splitKey[1];

            Writer.Write(ulong.Parse(instance, NumberStyles.HexNumber));
            Writer.Write(uint.Parse(type, NumberStyles.HexNumber));
            Writer.Write(uint.Parse(group, NumberStyles.HexNumber));
        }

        public void WriteSchemaHeader(int nameOffset, uint nameHash, uint schemaHash, uint schemaSize, int columnOffset, uint numColumns)
        {
            Writer.Write(nameOffset);
            Writer.Write(nameHash);
            Writer.Write(schemaHash);
            Writer.Write(schemaSize);
            Writer.Write(columnOffset);
            Writer.Write(numColumns);
        }

        public void WriteSchemaColumn(int nameOffset, uint nameHash, ushort dataType, ushort flags, int offset, int schemaOffset)
        {
            Writer.Write(nameOffset);
            Writer.Write(nameHash);
            Writer.Write(dataType);
            Writer.Write(flags);
            Writer.Write(offset);
            Writer.Write(schemaOffset);
        }
    }
}
