using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SimFilters
{
    [ElementTypeData("Sim Filter", false, ElementTypes = new[] { typeof(SimFilter) }, PresetFolders = new[] { "SimFilter" })]
    public class SimFilter : Element, IExportableElement
    {
        public ObservableCollection<SimFilterTermItem> Terms { get; } = new ObservableCollection<SimFilterTermItem>();

        public bool BanTraitGrimReaper { get; set; } = true;
        public bool BanTraitEventNPCs { get; set; } = true;
        public bool BanTraitAlienPollinator { get; set; } = true;
        public bool BanTraitPoliceStationCriminal { get; set; } = true;
        public bool BanTraitSkeletons { get; set; } = true;
        public bool BanTraitScarecrow { get; set; } = true;
        public bool BanTraitFlowerBunny { get; set; } = true;
        public bool BanTraitBabyAriel { get; set; } = true;
        public bool BanTraitNightStalker { get; set; } = true;
        public bool BanTraitMagicSages { get; set; } = true;
        public bool BanTraitProfessors { get; set; } = true;
        public bool BanTraitBatuuNPCs { get; set; } = true;
        public bool BanTraitTownMascot { get; set; } = true;
        public bool BanTraitGuidry { get; set; } = true;
        public bool BanTraitBonehilda { get; set; } = true;
        public bool BanTraitTemperance { get; set; } = true;
        public bool BanTraitFatherWinter { get; set; } = true;
        public bool BanAnimals { get; set; } = true;
        public bool BanNonHouseholdGhosts { get; set; } = true;
        public bool BanSimsWhoCantBeOutside { get; set; } = true;
        public bool BanHiddenSims { get; set; } = true;
        public bool MustBeCompatibleRegion { get; set; } = true;
        public bool IncludeLod { get; set; } = true;


        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "TunableSimFilter";
            tuning.InstanceType = "sim_filter";
            tuning.Module = "filters.tunable";

            var filterTermsList = tuning.Get<TunableList>("_filter_terms");

            TuneStandard(filterTermsList);

            foreach(var term in Terms)
            {
                term.Term.OnExport(filterTermsList);
            }

            var tunableVariant2 = tuning.Set<TunableVariant>("_household_templates_override", "enabled");
            var tunableList2 = tunableVariant2.Get<TunableList>("enabled");
            tunableList2.Set<TunableBasic>(null, "98542");
            tuning.Set<TunableBasic>("_template_chooser", "");
            tuning.Set<TunableBasic>("use_weighted_random", "True");

            TuningExport.AddToQueue(tuning);
        }

        private void TuneStandard(TunableList filterTermsList)
        {
            var traitBlacklistKeys = new List<ulong>();

            if (BanTraitGrimReaper)
            {
                traitBlacklistKeys.Add(16851);
            }
            if (BanTraitEventNPCs)
            {
                traitBlacklistKeys.Add(133798);
            }
            if (BanTraitAlienPollinator)
            {
                traitBlacklistKeys.Add(112688);
            }
            if (BanTraitPoliceStationCriminal)
            {
                traitBlacklistKeys.Add(116487);
            }
            if (BanTraitSkeletons)
            {
                traitBlacklistKeys.Add(177810);
                traitBlacklistKeys.Add(178437);
            }
            if (BanTraitScarecrow)
            {
                traitBlacklistKeys.Add(187088);
            }
            if (BanTraitFlowerBunny)
            {
                traitBlacklistKeys.Add(186785);
            }
            if (BanTraitBabyAriel)
            {
                traitBlacklistKeys.Add(202424);
            }
            if (BanTraitNightStalker)
            {
                traitBlacklistKeys.Add(216314);
            }
            if (BanTraitMagicSages)
            {
                traitBlacklistKeys.Add(212849);
                traitBlacklistKeys.Add(212850);
                traitBlacklistKeys.Add(212851);
            }
            if (BanTraitProfessors)
            {
                traitBlacklistKeys.Add(224965);
                traitBlacklistKeys.Add(224966);
            }
            if (BanTraitBatuuNPCs)
            {
                traitBlacklistKeys.Add(239021);
                traitBlacklistKeys.Add(238970);
                traitBlacklistKeys.Add(238708);
                traitBlacklistKeys.Add(238969);
                traitBlacklistKeys.Add(239020);
                traitBlacklistKeys.Add(231263);
            }
            if (BanTraitTownMascot)
            {
                traitBlacklistKeys.Add(249203);
            }
            if (BanTraitGuidry)
            {
                traitBlacklistKeys.Add(252849);
            }
            if (BanTraitBonehilda)
            {
                traitBlacklistKeys.Add(253237);
            }
            if (BanTraitTemperance)
            {
                traitBlacklistKeys.Add(256353);
            }
            if (BanTraitFatherWinter)
            {
                traitBlacklistKeys.Add(183343);
            }

            if (traitBlacklistKeys.Count > 0)
            {
                var blacklistVariant = filterTermsList.Set<TunableVariant>(null, "trait_blacklist");
                var blacklistTuple = blacklistVariant.Get<TunableTuple>("trait_blacklist");
                var tunableList1 = blacklistTuple.Get<TunableList>("traits");

                foreach(var key in traitBlacklistKeys)
                {
                    tunableList1.Set<TunableBasic>(null, key);
                }
            }

            if (IncludeLod)
            {
                filterTermsList.Set<TunableVariant>(null, "sim_info_lod");
            }

            if (BanAnimals)
            {
                filterTermsList.Set<TunableVariant>(null, "species");
            }

            if (BanNonHouseholdGhosts)
            {
                var tunableVariant1 = filterTermsList.Set<TunableVariant>(null, "is_ghost");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("is_ghost");
                tunableTuple1.Set<TunableBasic>("invert_score", "True");
                tunableTuple1.Set<TunableBasic>("require_npc", "False");
            }

            if (BanSimsWhoCantBeOutside)
            {
                filterTermsList.Set<TunableVariant>(null, "can_be_outside");
            }

            if (BanHiddenSims)
            {
                var tunableVariant1 = filterTermsList.Set<TunableVariant>(null, "is_hidden");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("is_hidden");
                tunableTuple1.Set<TunableBasic>("invert_score", "True");
            }

            if (MustBeCompatibleRegion)
            {
                filterTermsList.Set<TunableVariant>(null, "in_compatible_region");
            }
        }
    }
}
