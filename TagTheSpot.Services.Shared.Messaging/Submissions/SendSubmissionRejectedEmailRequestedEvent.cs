using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Submissions
{
    public sealed record SendSubmissionRejectedEmailRequestedEvent(
        Guid SubmissionId,
        string Recipient,
        string SubmissionLink,
        string RejectionReason,
        DateTime SubmittedAt,
        DateTime RejectedAt) : EventBase;
}
