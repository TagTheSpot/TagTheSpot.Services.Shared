using TagTheSpot.Services.Shared.Messaging.Events.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Events.Submissions
{
    public sealed record SubmissionRejectedEvent(
        Guid SubmissionId,
        string RejectionReason) : EventBase;
}
