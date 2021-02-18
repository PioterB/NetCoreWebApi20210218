namespace FleetManagement.Security
{
    public interface IAuthorizationService
    {
        ApplicationUser Authorize(string identity, string secret);
    }
}