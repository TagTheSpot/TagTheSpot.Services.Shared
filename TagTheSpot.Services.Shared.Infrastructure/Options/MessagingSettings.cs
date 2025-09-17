using System.ComponentModel.DataAnnotations;
using TagTheSpot.Services.Shared.Abstractions.Options;

namespace TagTheSpot.Services.Shared.Infrastructure.Options
{
    public sealed class MessagingSettings : IAppOptions
    {
        public static string SectionName => nameof(MessagingSettings);

        [Required]
        public required string QueueName { get; init; }
    }
}
