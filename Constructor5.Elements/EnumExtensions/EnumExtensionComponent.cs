using Constructor5.Base.ComponentSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Constructor5.Elements.EnumExtensions
{
    public abstract class EnumExtensionComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(EnumExtensionExportContext context);
    }
}
