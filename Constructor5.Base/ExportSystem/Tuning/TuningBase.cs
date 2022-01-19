using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Constructor5.Base.ExportSystem.Tuning
{
    public abstract class TuningBase
    {
        [XmlElement("T", typeof(TunableBasic))]
        [XmlElement("E", typeof(TunableEnum))]
        [XmlElement("L", typeof(TunableList))]
        [XmlElement("U", typeof(TunableTuple))]
        [XmlElement("V", typeof(TunableVariant))]
        public List<TunableBase> Tunables { get; set; } = new List<TunableBase>();

        public T Get<T>(string name) where T : TunableBase
        {
            var tunable = name != null ? Tunables.Find(x => x.Name == name && x is T) : null;
            if (tunable == null)
            {
                tunable = Reflection.CreateObject<T>();
                tunable.Name = name;
                Tunables.Add(tunable);
            }
            return (T)tunable;
        }

        public T GetExistingOnly<T>(string name) where T : TunableBase
        {
            var tunable = name != null ? Tunables.Find(x => x.Name == name && x is T) : null;
            return (T)tunable;
        }

        public T GetVariant<T>(string name, string variant) where T : TunableBase
        {
            var variantTunable = Get<TunableVariant>(name);
            if (variant != null)
            {
                variantTunable.Variant = variant;
            }
            return variantTunable.Get<T>(variant);
        }

        public TunableBase Set<T>(string name, string value) where T : TunableBase
        {
            var tunable = name != null ? Tunables.Find(x => x.Name == name && x is T) : null;
            if (tunable == null)
            {
                tunable = Reflection.CreateObject<T>();
                tunable.Name = name;
                if (value != null)
                {
                    Tunables.Add(tunable);
                }
            }

            if (value == null)
            {
                return tunable;
            }

            if (tunable is TunableVariant tunableVariant)
            {
                tunableVariant.Variant = value;
            }
            else
            {
                tunable.Value = value;
            }

            return tunable;
        }

        public TunableBase Set<T>(string name, ITunableValueObject value) where T : TunableBase
            => Set<T>(name, value.GetTunableValue());

        public T Set<T>(string name, object value) where T : TunableBase
        {
            if (value is ITunableValueObject)
            {
                return (T)Set<T>(name, value as ITunableValueObject);
            }

            return (T)Set<T>(name, value.ToString());
        }

        public TunableBase SetVariant<T>(string name, string variant, string value) where T : TunableBase
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var variantTunable = Get<TunableVariant>(name);
            variantTunable.Variant = variant;
            variantTunable.Set<T>(variant, value);
            return variantTunable;
        }
    }
}