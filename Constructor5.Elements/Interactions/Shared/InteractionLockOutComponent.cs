using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Xml;

namespace Constructor5.Elements.Interactions.Shared
{
    [MixerInteractionComponent]
    [XmlSerializerExtraType]
    public class InteractionLockOutComponent : InteractionComponent
    {
        public override string ComponentLabel => "Lock Out Time";

        public IntBounds InitialLockOutTime { get; set; } = new IntBounds();
        public IntBounds LockOutTime { get; set; } = new IntBounds();

        protected internal override void OnExport(InteractionExportContext context)
        {
            if (InitialLockOutTime.RestrictLowerBound || InitialLockOutTime.RestrictUpperBound)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("lock_out_time_initial", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");

                if (InitialLockOutTime.RestrictLowerBound)
                {
                    tunableTuple1.Set<TunableBasic>("lower_bound", InitialLockOutTime.LowerBound);
                }
                
                if (InitialLockOutTime.RestrictUpperBound)
                {
                    tunableTuple1.Set<TunableBasic>("upper_bound", InitialLockOutTime.UpperBound);
                }
            }

            if (LockOutTime.RestrictLowerBound || LockOutTime.RestrictUpperBound)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("lock_out_time", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("interval");

                if (LockOutTime.RestrictLowerBound)
                {
                    tunableTuple2.Set<TunableBasic>("lower_bound", LockOutTime.LowerBound);
                }

                if (LockOutTime.RestrictUpperBound)
                {
                    tunableTuple2.Set<TunableBasic>("upper_bound", LockOutTime.UpperBound);
                }
            }
        }
    }
}