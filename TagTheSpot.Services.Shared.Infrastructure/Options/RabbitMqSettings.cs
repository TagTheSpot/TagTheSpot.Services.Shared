using System.ComponentModel.DataAnnotations;

namespace TagTheSpot.Services.Shared.Infrastructure.Options
{
    public sealed class RabbitMqSettings
    {
        public const string SectionName = nameof(RabbitMqSettings);

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
