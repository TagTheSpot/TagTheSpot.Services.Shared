namespace TagTheSpot.Services.Shared.Abstractions.Options
{
    public interface IAppOptions
    {
        /// <summary>
        /// The configuration section name this options class should bind to.
        /// </summary>
        static abstract string SectionName { get; }
    }
}
