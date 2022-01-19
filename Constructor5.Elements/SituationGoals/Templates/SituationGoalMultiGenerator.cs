using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.SituationGoals.Templates
{
    public abstract class SituationGoalMultiGenerator : SituationGoalTemplate
    {
        protected internal abstract ulong[] GetInstanceKeys(SituationGoalExportContext context);
    }
}
