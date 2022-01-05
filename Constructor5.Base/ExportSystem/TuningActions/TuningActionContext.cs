using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using System.Collections.Generic;
using System.Xml;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    public class TuningActionContext
    {
        public TuningActionContext()
        {
        }

        public TuningActionContext(TuningActionContext existing)
        {
            Exporter = existing.Exporter;
            XmlReader = existing.XmlReader;
            Tuning = existing.Tuning;
            DataContext = existing.DataContext;
            foreach(var existingVariable in existing.Variables)
            {
                Variables.Add(existingVariable.Key, existingVariable.Value);
            }
        }

        public void SetVariable(string varName, string value)
        {
            if (Variables.ContainsKey(varName))
            {
                Variables[varName] = value;
            }
            else
            {
                Variables.Add(varName, value);
            }
        }

        public object DataContext { get; set; }
        public Exporter Exporter { get; set; }
        public TuningBase Tuning { get; set; }
        public XmlReader XmlReader { get; set; }
        public Dictionary<string, string> Variables { get; } = new Dictionary<string, string>();
    }
}