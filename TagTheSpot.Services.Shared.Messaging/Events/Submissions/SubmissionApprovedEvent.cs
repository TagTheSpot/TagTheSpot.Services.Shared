using TagTheSpot.Services.Shared.Messaging.Events.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Events.Submissions
{
    public sealed record SubmissionApprovedEvent(
        Guid SubmissionId) : EventBase;
}
