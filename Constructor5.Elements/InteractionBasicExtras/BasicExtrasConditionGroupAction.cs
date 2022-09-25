using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Constructor5.Elements.InteractionBasicExtras
{
    [XmlSerializerExtraType]
    public class BasicExtrasConditionGroupAction : BasicExtrasConditionGroupItem
    {
        public BasicExtra Action { get; set; } = new EmptyBasicExtra();
    }
}
