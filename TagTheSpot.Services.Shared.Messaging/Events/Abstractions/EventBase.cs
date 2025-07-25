namespace TagTheSpot.Services.Shared.Messaging.Events.Abstractions
{
    public abstract record EventBase
    {
        public Guid EventId { get; init; } = Guid.NewGuid();

        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        public string Version { get; init; } = "1.0";
    }
}
