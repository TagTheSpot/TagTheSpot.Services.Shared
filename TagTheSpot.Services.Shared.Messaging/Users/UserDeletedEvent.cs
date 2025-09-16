using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Users
{
    public sealed record UserDeletedEvent(
        Guid UserId) : EventBase;
}
