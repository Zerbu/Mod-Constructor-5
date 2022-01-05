using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Xml;
using System;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    public class SituationGoalInfoComponent : SituationGoalComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Goal Info";

        public int Cooldown { get; set; }
        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public int Iterations { get; set; } = 1;
        public STBLString Name { get; set; } = new STBLString();
        public int Score { get; set; }
        public bool SetCooldown { get; set; }
        public bool SetIterations { get; set; }
        public bool SetScore { get; set; }

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("_display_data", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("instance_display_tooltip", "enabled");
            tunableVariant2.Set<TunableBasic>("enabled", Description);
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("instance_display_icon", "enabled");
            tunableVariant3.Set<TunableBasic>("enabled", Icon);
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("instance_display_name", "enabled");
            tunableVariant4.Set<TunableBasic>("enabled", Name);

            var holidayContextModifier = Element.GetContextModifier<HolidayTraditionContextModifier>();

            if (holidayContextModifier == null)
            {
                if (SetScore)
                {
                    context.Tuning.Set<TunableBasic>("_score", Score);
                }

                if (SetCooldown)
                {
                    context.Tuning.Set<TunableBasic>("_cooldown", Cooldown);
                }
            }

            if (SetIterations)
            {
                context.Tuning.Set<TunableBasic>("_iterations", Iterations);
            }
            else if (holidayContextModifier != null)
            {
                context.Tuning.Set<TunableBasic>("_iterations", 1);
            }

            if (holidayContextModifier != null)
            {
                TuneHolidayTradition(context);
            }

            context.Tuning.Set<TunableBasic>("audio_sting_on_complete", "39b2aa4a:00000000:ed52c39bcc2a7111");
        }

        private void TuneHolidayTradition(SituationGoalExportContext context)
        {
            var iterations = SetIterations ? Iterations : 1;

            if (iterations > 100)
            {
                Exporter.Current.AddError("Holiday tradition goals cannot have more than 100 iterations.");
                return;
            }

            var scoreOnComplete = 0;
            var scorePerIteration = 0;

            switch (iterations)
            {
                case 1:
                    scorePerIteration = 100;
                    scoreOnComplete = 100;
                    break;
                case 2:
                    scorePerIteration = 50;
                    scoreOnComplete = 50;
                    break;
                case 3:
                    scorePerIteration = 30;
                    scoreOnComplete = 40;
                    break;
                case 4:
                    scorePerIteration = 25;
                    scoreOnComplete = 25;
                    break;
                case 5:
                    scorePerIteration = 20;
                    scoreOnComplete = 20;
                    break;
                case 6:
                    scorePerIteration = 15;
                    scoreOnComplete = 25;
                    break;
                default:
                    scorePerIteration = (int)Math.Floor(100d / iterations);
                    scoreOnComplete = scorePerIteration + (100 - (scorePerIteration * iterations));
                    break;
            }

            context.Tuning.Set<TunableBasic>("_score", scoreOnComplete);

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("score_on_iteration_complete", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", scorePerIteration);
        }
    }
}