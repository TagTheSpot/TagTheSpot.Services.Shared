using System.ComponentModel.DataAnnotations;

namespace TagTheSpot.Services.Shared.Infrastructure.Options
{
    public sealed class DbSettings
    {
        public const string SectionName = nameof(DbSettings);

        [Required]
        public required string ConnectionString { get; init; }
    }
}
