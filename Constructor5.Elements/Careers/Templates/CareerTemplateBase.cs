using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.CareerTracks;

namespace Constructor5.Elements.Careers.Templates
{
    public abstract class CareerTemplateBase
    {
        public abstract string Label { get; }

        public CareerTemplateMessageOverride MessageActiveCareerEnd { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName}'s work day will end in one hour. {M0.He}{F0.She} should wrap up what {M0.he}{F0.she} is doing. Each work day can be extended once by clicking on the Event Timer.");

        public CareerTemplateMessageOverride MessageActiveCareerStart { get; set; }
            = new CareerTemplateMessageOverride("It's time for {0.SimFirstName} to head off to work. Would you care to follow?");

        public CareerTemplateMessageOverride MessageBossCalling { get; set; }
            = new CareerTemplateMessageOverride("My boss is calling. Should I pick it up?");

        public CareerTemplateMessageOverride MessageCallInSick { get; set; }
            = new CareerTemplateMessageOverride("Call in sick");

        public CareerTemplateMessageOverride MessageEndDemoted { get; set; }
            = new CareerTemplateMessageOverride("Oh no! {0.SimFirstName} has been demoted. {M0.He}{F0.She} is back to being {1.String|enAn}.");

        public CareerTemplateMessageOverride MessageEndEarnedVacationDay { get; set; }
            = new CareerTemplateMessageOverride("\n\n{0.SimFirstName} has earned a Vacation Day!");

        public CareerTemplateMessageOverride MessageEndFakeSick { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} earned {4.Money} while home \"sick.\"{5.String}");

        public CareerTemplateMessageOverride MessageEndFamilyLeave { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has earned {4.Money} today.{5.String}");

        public CareerTemplateMessageOverride MessageEndFired { get; set; }
            = new CareerTemplateMessageOverride("Bad news! {0.SimFirstName} was fired from {M0.his}{F0.her} job at {3.String}.");

        public CareerTemplateMessageOverride MessageEndFiredTitle { get; set; }
            = new CareerTemplateMessageOverride("Fired");

        public CareerTemplateMessageOverride MessageEndGreat { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} brought home {4.Money} today. {M0.He}{F0.She} did some great work, too! {5.String}");

        public CareerTemplateMessageOverride MessageEndHoliday { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has earned {4.Money} on {M0.his}{F0.her} holiday.");

        public CareerTemplateMessageOverride MessageEndIndoorsGreat { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} brought home {4.Money} today. Working indoors is a drag for {M0.him}{F0.her} as {M0.he}{F0.she} lives an Outdoorsy Lifestyle, but {M0.he}{F0.she} did some great work anyways! {5.String}");

        public CareerTemplateMessageOverride MessageEndIndoorsNeutral { get; set; }
            = new CareerTemplateMessageOverride("What a day of work! {0.SimFirstName} is back home and {M0.he}{F0.she} has earned {4.Money}. Despite working inside and going against {M0.his}{F0.her} Outdoorsy Lifestyle, {M0.he}{F0.she} still managed to make ends meet.");

        public CareerTemplateMessageOverride MessageEndIndoorsPoor { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} earned {4.Money} but performed poorly at work today, because of {M0.his}{F0.her} distaste from working indoors thanks to the Outdoorsy Lifestyle. {5.String}");

        public CareerTemplateMessageOverride MessageEndIndoorsSuperb { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} brought home {4.Money} today. Working indoors is a drag for {M0.he}{F0.her} as {M0.he}{F0.she} lives an Outdoorsy Lifestyle, but {M0.he}{F0.she} did some superb work anyways! {5.String}");

        public CareerTemplateMessageOverride MessageEndIndoorsTerrible { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} earned {4.Money} but performed terribly at work today, because of {M0.his}{F0.her} distaste from working indoors thanks to the Outdoorsy Lifestyle. {5.String}");

        public CareerTemplateMessageOverride MessageEndNeutral { get; set; }
            = new CareerTemplateMessageOverride("What a day of work! {0.SimFirstName} is back home and {M0.he}{F0.she} has earned {4.Money}!");

        public CareerTemplateMessageOverride MessageEndPoor { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} earned {4.Money} but performed poorly at work today. {5.String}");

        public CareerTemplateMessageOverride MessageEndPromoted { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has been promoted to {1.String}!\n\n{M0.He}{F0.She} will now make an additional {6.Money} per hour, for a grand total of {5.Money} per hour.\n\n{M0.His}{F0.Her} next shift is {4.DayOfWeekLong} at {4.TimeShort}.\n\n");

        public CareerTemplateMessageOverride MessageEndPromotedBonus { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has been promoted to {1.String}!\n\n{M0.He}{F0.She} will now make an additional {6.Money} per hour, for a grand total of {5.Money} per hour.\n\n{M0.He}{F0.She} has also received the following bonus:\n{8.String}\n\n{M0.His}{F0.Her} next shift is {4.DayOfWeekLong} at {4.TimeShort}.\n\n");

        public CareerTemplateMessageOverride MessageEndPromotedTitle { get; set; }
            = new CareerTemplateMessageOverride("Promoted to {1.String}");

        public CareerTemplateMessageOverride MessageEndPTO { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has earned {4.Money} on {M0.his}{F0.her} day off.{5.String}");

        public CareerTemplateMessageOverride MessageEndRaise { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has been given a raise as {1.String} for superior work performance!\n\n{M0.He}{F0.She} will now make an additional {6.Money} per hour, for a grand total of {5.Money} per hour.");

        public CareerTemplateMessageOverride MessageEndRaiseBonus { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has been given a raise as {1.String} for superior work performance!\n\n{M0.He}{F0.She} will now make an additional {6.Money} per hour, for a grand total of {5.Money} per hour.\n\n{M0.He}{F0.She} has also received the following bonus:\n{7.String}");

        public CareerTemplateMessageOverride MessageEndRaiseTitle { get; set; }
            = new CareerTemplateMessageOverride("Earned a Raise");

        public CareerTemplateMessageOverride MessageEndSuperb { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} brought home {4.Money} today. {M0.He}{F0.She} did some superb work too! {5.String}");

        public CareerTemplateMessageOverride MessageEndTerrible { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} earned {4.Money} but performed terribly at work today. {5.String}");

        public CareerTemplateMessageOverride MessageEndTitle { get; set; }
            = new CareerTemplateMessageOverride("Demoted to {1.String}");

        public CareerTemplateMessageOverride MessageGoToWork { get; set; }
            = new CareerTemplateMessageOverride("Go to work");

        public CareerTemplateMessageOverride MessageHoliday { get; set; }
            = new CareerTemplateMessageOverride("<font color='#03ADEE'>Holiday</font>");

        public CareerTemplateMessageOverride MessageHolidayDaysEarned { get; set; }
            = new CareerTemplateMessageOverride("<font color='#03ADEE'>Holiday - {1.Number} {S1.day}{P1.days} earned. </font>");

        public CareerTemplateMessageOverride MessageHourToWork { get; set; }
            = new CareerTemplateMessageOverride("Work for {0.SimFirstName} starts in about one hour.");

        public CareerTemplateMessageOverride MessageHourToWorkOptions { get; set; }
            = new CareerTemplateMessageOverride("Work for {0.SimFirstName} starts in about one hour. What would you like to do?");

        public CareerTemplateMessageOverride MessageJoinedCareer { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} is now {1.String|enAn} at {3.String}. {M0.He}{F0.She} starts {4.DayOfWeekLong} at {4.TimeShort}!");

        public CareerTemplateMessageOverride MessageJoinedCareerTitle { get; set; }
            = new CareerTemplateMessageOverride("Entered the {2.String} Career");

        public CareerTemplateMessageOverride MessageMissingWork { get; set; }
            = new CareerTemplateMessageOverride("Missing Work");

        public CareerTemplateMessageOverride MessageMissWork { get; set; }
            = new CareerTemplateMessageOverride("Miss Work");

        public CareerTemplateMessageOverride MessageOffToWork { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} is off to work!");

        public CareerTemplateMessageOverride MessageOnFamilyLeave { get; set; }
            = new CareerTemplateMessageOverride("<font color='#03ADEE'>On Family Leave</font>");

        public CareerTemplateMessageOverride MessageOnVacation { get; set; }
            = new CareerTemplateMessageOverride("<font color='#03ADEE'>On Vacation</font>");

        public CareerTemplateMessageOverride MessageOnVacationDaysEarned { get; set; }
            = new CareerTemplateMessageOverride("<font color='#03ADEE'>On Vacation - {1.Number} {S1.day}{P1.days} earned. </font>");

        public CareerTemplateMessageOverride MessagePhoneCall { get; set; }
            = new CareerTemplateMessageOverride("Incoming Phone Call");

        public CareerTemplateMessageOverride MessageQuit { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} has quit {M0.his}{F0.her} job at {3.String}. {M0.He}{F0.She} decided it was time for a new direction, career-wise.");

        public CareerTemplateMessageOverride MessageQuitTitle { get; set; }
            = new CareerTemplateMessageOverride("Quit the {2.String} Career");

        public CareerTemplateMessageOverride MessageSituationLeaveConfirmation { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName} is a bit occupied right now. Should {M0.he}{F0.she} still go to work?");

        public CareerTemplateMessageOverride MessageTakePTO { get; set; }
            = new CareerTemplateMessageOverride("Take PTO");

        public CareerTemplateMessageOverride MessageTakingSickDay { get; set; }
            = new CareerTemplateMessageOverride("Taking Sick Day");

        public CareerTemplateMessageOverride MessageWorkFromHome { get; set; }
            = new CareerTemplateMessageOverride("Work from home");

        public CareerTemplateMessageOverride MessageWorkFromHomeNegative { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName}'s boss was disappointed with the work {M0.he}{F0.she} did from home and {M0.he}{F0.she} made {4.Money}.");

        public CareerTemplateMessageOverride MessageWorkFromHomePositive { get; set; }
            = new CareerTemplateMessageOverride("{0.SimFirstName}'s boss was happy with the work {M0.he}{F0.she} did from home, and {M0.he}{F0.she} made {4.Money}.");

        public abstract int GetBasePerformance(int level);
        public abstract int GetNegativeEmotionModifier(int level);
        public abstract int GetStandardEmotionModifier(int level);

        protected internal abstract void OnExport(CareerExportContext context);

        protected internal abstract void TuneOvermax(TuningBase tuning, CareerTrack track);
    }
}