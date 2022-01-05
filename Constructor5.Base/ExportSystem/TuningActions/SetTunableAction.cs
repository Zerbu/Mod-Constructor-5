using Constructor5.ActionSystem.TuningActions;
using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("T")]
    public class SetTunableAction : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var name = context.XmlReader.GetAttribute("n");
            context.XmlReader.Read();
            var value = context.XmlReader.Value;

            if (value.StartsWith("$"))
            {
                var varName = value.Substring(1);

                if (value.EndsWith("()"))
                {
                    var method = context.DataContext.GetType().GetMethod(value.Replace("$", "").Replace("()", ""));
                    value = method.Invoke(context.DataContext, null).ToString();
                }
                else
                {
                    if (context.Variables.ContainsKey(varName))
                    {
                        value = context.Variables[varName];
                    }
                    else
                    {
                        value = PropertyExport.GetString(context.DataContext, varName);
                    }
                }
            }

            SetTunable(context, name, value);
        }

        protected virtual void SetTunable(TuningActionContext context, string name, string value)
            => context.Tuning.Set<TunableBasic>(name, value);
    }
}
