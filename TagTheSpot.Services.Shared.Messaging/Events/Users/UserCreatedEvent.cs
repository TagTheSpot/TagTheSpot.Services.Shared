using TagTheSpot.Services.Shared.Messaging.Events.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Events.Users
{
    public sealed record UserCreatedEvent(
        Guid UserId,
        string Email,
        string Role) : EventBase;
}
