using System;
using JPProject.Domain.Core.Events;

namespace JPProject.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        : base(EventTypes.Failure)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}