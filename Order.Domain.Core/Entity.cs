using Flunt.Notifications;

namespace Person.Domain.Core
{
    public abstract class Entity : Notifiable
    {
        public virtual int Id { get; protected set; }
        public Entity()
        {
        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}