using System.ComponentModel.DataAnnotations;
using TagTheSpot.Services.Shared.Abstractions.Options;

namespace TagTheSpot.Services.Shared.Infrastructure.Options
{
    public sealed class RabbitMqSettings : IAppOptions
    {
        public static string SectionName => nameof(RabbitMqSettings);

        [Required]
        public required string Host { get; init; }

        [Required]
        public required string VirtualHost { get; init; }

        [Required]
        public required string Username { get; init; }

        [Required]
        public required string Password { get; init; }
    }
}
