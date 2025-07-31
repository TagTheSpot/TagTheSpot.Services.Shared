using TagTheSpot.Services.Shared.Messaging.Events.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Events.Submissions
{
    public sealed record SpotSubmittedEvent(
        Guid SubmissionId,
        Guid UserId,
        Guid CityId,
        string CityName,
        double Latitude,
        double Longitude,
        string SpotType,
        string Description,
        List<string> ImagesUrls,
        DateTime SubmittedAt,
        bool? IsCovered,
        bool? Lighting,
        string? SkillLevel,
        string? Accessibility,
        string? Condition) : EventBase;
}
