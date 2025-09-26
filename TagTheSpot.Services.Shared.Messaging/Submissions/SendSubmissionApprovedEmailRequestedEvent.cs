using TagTheSpot.Services.Shared.Messaging.Abstractions;

namespace TagTheSpot.Services.Shared.Messaging.Submissions
{
    public sealed record SendSubmissionApprovedEmailRequestedEvent(
        Guid SubmissionId,
        string Recipient,
        string SubmissionLink,
        DateTime SubmittedAt,
        DateTime ApprovedAt) : EventBase;
}
