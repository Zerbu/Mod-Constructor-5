using Constructor5.Base.ElementSystem;
using Constructor5.Base.Icons;

namespace Constructor5.Base.PropertyTypes
{
    public class NotificationOrDialog
    {
        public string AudioSting { get; set; }
        public bool IsAnonymousCaller { get; set; }
        public NotificationTypes NotificationType { get; set; } = NotificationTypes.Notification;
        public STBLString OKText { get; set; } = new STBLString();
        public NotificationIcon PrimaryIcon { get; set; } = new NotificationIcon();
        public NotificationIcon SecondaryIcon { get; set; } = new NotificationIcon();
        public STBLString Text { get; set; } = new STBLString();
        public STBLString Title { get; set; } = new STBLString();

        public bool HasLeftIcon { get; set; }
        public ElementIcon YesNoLeftIcon { get; set; } = new ElementIcon();
        public STBLString YesNoLeftIconText { get; set; } = new STBLString();

        public bool HasMiddleIcon { get; set; }
        public ElementIcon YesNoMiddleIcon { get; set; } = new ElementIcon();
        public STBLString YesNoMiddleIconText { get; set; } = new STBLString();

        public bool HasRightIcon { get; set; }
        public ElementIcon YesNoRightIcon { get; set; } = new ElementIcon();
        public STBLString YesNoRightIconText { get; set; } = new STBLString();

        public ReferenceList YesActions { get; set; } = new ReferenceList();
        public ReferenceList NoActions { get; set; } = new ReferenceList();

        public bool RequireSelfDiscovery { get; set; }
    }
}
