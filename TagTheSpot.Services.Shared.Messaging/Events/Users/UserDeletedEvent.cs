using TagTheSpot.Services.Shared.Messaging.Events.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Events.Users
{
    public sealed record UserDeletedEvent(
        Guid UserId) : EventBase;
}
