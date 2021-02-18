namespace FleetManagement.API.Controllers
{
    public class MissingItemModel
    {
        public string Error { get; }

        public MissingItemModel(string reason)
        {
            Error = reason;
        }
    }
}