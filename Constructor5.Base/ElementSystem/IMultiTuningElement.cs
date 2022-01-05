using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ElementSystem
{
    public interface IMultiTuningElement
    {
        ulong[] GetInstanceKeys(out bool hasMultiTuning);
    }
}
