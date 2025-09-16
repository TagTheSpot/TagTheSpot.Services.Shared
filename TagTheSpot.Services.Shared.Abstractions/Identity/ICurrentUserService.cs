using TagTheSpot.Services.Shared.Domain.Users;

namespace TagTheSpot.Services.Shared.Abstractions.Identity
{
    public interface ICurrentUserService
    {
        Guid GetUserId();

        Role GetRole();
    }
}
