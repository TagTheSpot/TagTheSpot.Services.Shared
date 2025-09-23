namespace TagTheSpot.Services.Shared.Messaging.Auth
{
    public sealed record SendConfirmationEmailRequestedEvent(
        string Recipient,
        string ConfirmationLink);
}