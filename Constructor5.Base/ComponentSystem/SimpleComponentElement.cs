using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Base.ComponentSystem
{
    public class SimpleComponentElement<T> : Element, IHasComponents where T : ElementComponent
    {
        public List<T> Components { get; } = new List<T>();

        public TType GetComponent<TType>() where TType : T => (TType)Components.First(x => x is TType);

        ElementComponent[] IHasComponents.GetSortedUserFacingComponents()
                    => Components.OrderBy(x => ((IComponentDisplayOrder)x).ComponentDisplayOrder).ThenBy(x => x.ComponentLabel).ToArray();

        protected void AddComponent(Type type)
        {
            var component = Components.FirstOrDefault(x => x.GetType() == type);

            if (component == null)
            {
                component = (T)Reflection.CreateObject(type);
                Components.Add(component);
            }

            component.Element = this;
        }
    }
}