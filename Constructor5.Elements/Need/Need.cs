using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Commodities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.Need
{
    [ElementTypeData(ElementTypes = new[] { typeof(Commodity) }, PresetFolders = new[] { "Need" })]
    public class Need : Element
    {
    }
}
