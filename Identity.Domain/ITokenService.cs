namespace FleetManagement.Security
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}