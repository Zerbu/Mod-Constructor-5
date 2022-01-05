using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Constructor5.Base.ElementSystem
{
    public static class ElementSaver
    {
        public static void LoadAll()
        {
            foreach (var file in Directory.GetFiles(Project.GetDirectory("Elements"), "*.xml"))
            {
                try
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var virtualExtension = Path.GetExtension(fileName).Replace(".", "");
                    var element = (Element)XmlLoader.LoadFile(Reflection.GetTypeByName(virtualExtension), file);
                    ElementManager.Register(element);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occured while loading the following file: {file}\n\nThe file may be corrupted.\n\n{ex.Message}", "The Sims 4 Mod Constructor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void Save(Element element)
            => XmlSaver.SaveFile(element, $"{Project.GetDirectory("Elements")}/{element.Guid}.{element.GetType().Name}.xml");

        public static void SaveScheduled()
        {
            foreach (var obj in ScheduledElements.ToArray())
            {
                ((IAutosavableObject)obj).OnAutosave();
                if (!MarkedElements.ContainsKey(obj) || MarkedElements[obj].Count == 0)
                {
                    ScheduledElements.Remove(obj);
                }
            }
        }

        public static void Mark(Element element, object markedBy)
        {
            if (!MarkedElements.ContainsKey(element))
            {
                MarkedElements.Add(element, new HashSet<object>());
            }

            if (!MarkedElements[element].Contains(markedBy))
            {
                MarkedElements[element].Add(markedBy);
                ScheduledElements.Add(element);
            }
        }

        public static void ScheduleOneTime(Element obj) => ScheduledElements.Add(obj);

        public static void Unmark(Element element, object markedBy)
        {
            Debug.Assert(MarkedElements.ContainsKey(element));
            MarkedElements[element].Remove(markedBy);
        }

        private static Dictionary<Element, HashSet<object>> MarkedElements { get; } = new Dictionary<Element, HashSet<object>>();
        private static HashSet<Element> ScheduledElements { get; } = new HashSet<Element>();
    }
}
