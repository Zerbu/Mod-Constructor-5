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
    }
}
