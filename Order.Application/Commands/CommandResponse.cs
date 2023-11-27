using Flunt.Notifications;

namespace Person.Application.Commands
{
    public class CommandResponse
    {
        public IReadOnlyCollection<Notification> Notifications { get; protected set; }

        public bool Valid => (Notifications == null || Notifications.Count == 0);
        public bool Invalid => (Notifications != null && Notifications.Count != 0);

        public CommandResponse(IReadOnlyCollection<Notification> notifications)
        {
            Notifications = notifications;
        }
    }
}
