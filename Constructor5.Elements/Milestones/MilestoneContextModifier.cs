using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.Milestones
{
    [XmlSerializerExtraType]
    public class MilestoneContextModifier : ContextModifier
    {
        public Reference Milestone { get; set; } = new Reference();
    }
}
