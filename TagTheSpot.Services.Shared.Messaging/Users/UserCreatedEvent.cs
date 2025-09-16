using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Users
{
    public sealed record UserCreatedEvent(
        Guid UserId,
        string Email,
        string Role) : EventBase;
}
