namespace TagTheSpot.Services.Shared.Messaging.Auth
{
    public sealed record SendResetPasswordEmailRequestedEvent(
        string Recipient,
        string ResetPasswordLink);
}
