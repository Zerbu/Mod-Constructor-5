using Constructor5.Base.ElementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.LikesDislikes
{
    [ElementTypeData("Like/Dislike", false, ElementTypes = new[] { typeof(LikeDislike) })]
    public class LikeDislike : Element
    {
        public Reference DislikeTrait { get; set; } = new Reference();
        public Reference LikeTrait { get; set; } = new Reference();
    }
}
