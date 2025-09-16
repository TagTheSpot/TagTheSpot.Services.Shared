using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Submissions
{
    public sealed record SubmissionRejectedEvent(
        Guid SubmissionId,
        string RejectionReason) : EventBase;
}
