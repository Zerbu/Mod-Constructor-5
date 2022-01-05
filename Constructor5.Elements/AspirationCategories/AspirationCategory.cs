using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.AspirationCategories
{
    [ElementTypeData("Aspiration Category", false, ElementTypes = new[] { typeof(AspirationCategory) }, PresetFolders = new[] { "AspirationCategory" })]
    public class AspirationCategory : Element, IExportableElement
    {
        void IExportableElement.OnExport()
        {

        }
    }
}
