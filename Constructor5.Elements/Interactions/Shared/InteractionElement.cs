using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.Interactions.Shared
{
    public abstract class InteractionElement : Element, IHasComponents
    {
        public List<InteractionComponent> Components { get; } = new List<InteractionComponent>();

        public T GetComponent<T>() where T : InteractionComponent => (T)Components.FirstOrDefault(x => x is T);

        ElementComponent[] IHasComponents.GetSortedUserFacingComponents()
                    => Components.OrderBy(x => ((IComponentDisplayOrder)x).ComponentDisplayOrder).ThenBy(x => x.ComponentLabel).ToArray();

        protected void AddComponent(Type type)
        {
            var component = Components.FirstOrDefault(x => x.GetType() == type);

            if (component == null)
            {
                component = (InteractionComponent)Reflection.CreateObject(type);
                Components.Add(component);
            }

            component.Element = this;
        }
    }
}