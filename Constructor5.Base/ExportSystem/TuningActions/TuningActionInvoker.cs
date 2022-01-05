using Constructor5.ActionSystem.TuningActions;
using System;
using System.Xml;
using System.IO;
using Constructor5.Core;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    public static class TuningActionInvoker
    {
        public static void InvokeFromFile(string fileName, TuningActionContext context)
        {
            var file = $"TuningActions/{fileName}.xml";
            using (var reader = XmlReader.Create(file))
            {
                Invoke(reader, context);
            }
        }

        public static void InvokeFromString(string str, TuningActionContext context)
        {
            using (var reader = XmlReader.Create(new StringReader($"<Root>{str}</Root>")))
            {
                Invoke(reader, context);
            }
        }

        private static void Invoke(XmlReader reader, TuningActionContext context)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (!TuningActionRegistry.Content.ContainsKey(reader.Name))
                    {
                        continue;
                    }

                    var action = (TuningAction)Reflection.CreateObject(TuningActionRegistry.Content[reader.Name]);
                    action.Invoke(new TuningActionContext(context)
                    {
                        XmlReader = reader,
                        Tuning = context.Tuning
                    });
                }
            }
        }
    }
}