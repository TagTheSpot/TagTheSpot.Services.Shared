using System.ComponentModel.DataAnnotations;
using TagTheSpot.Services.Shared.Abstractions.Options;

namespace TagTheSpot.Services.Shared.Infrastructure.Options
{
    public sealed class DbSettings : IAppOptions
    {
        public static string SectionName => nameof(DbSettings);

        [Required]
        public required string ConnectionString { get; init; }
    }
}
