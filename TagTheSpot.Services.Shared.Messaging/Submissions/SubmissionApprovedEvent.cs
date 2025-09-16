using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Submissions
{
    public sealed record SubmissionApprovedEvent(
        Guid SubmissionId) : EventBase;
}
