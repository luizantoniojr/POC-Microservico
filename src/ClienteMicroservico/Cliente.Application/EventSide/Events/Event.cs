using MediatR;
using System;

namespace Cliente.Application.EventSide.Events
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
