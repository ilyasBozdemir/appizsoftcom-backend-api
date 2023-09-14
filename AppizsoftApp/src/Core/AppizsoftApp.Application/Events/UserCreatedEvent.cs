using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Events
{
    public class UserCreatedEvent : INotification
    {
        public Guid UserId { get; }

        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
