using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Prism.Events;

namespace Komdiagnostika.Events
{
    public class EntityUpdatedEvent : PubSubEvent<EntityUpdatedEvent>
    {
        public EntityState State;
        public BaseEntity Entity;
    }
}
