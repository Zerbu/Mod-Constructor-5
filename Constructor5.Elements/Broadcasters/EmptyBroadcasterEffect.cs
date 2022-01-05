using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.Elements.Broadcasters
{
    [SelectableObjectType("BroadcasterEffects", "Do Nothing")]
    [XmlSerializerExtraType]
    public class EmptyBroadcasterEffect : BroadcasterEffect
    {
        public EmptyBroadcasterEffect() => GeneratedLabel = "Do Nothing";

        protected internal override void OnExport(BroadcasterExportContext newContext)
        {
        }
    }
}
