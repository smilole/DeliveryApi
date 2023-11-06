namespace Delivery.Api.Classes
{
    public class SearchAddressModel
    {
        public Int64 objectId { get; set; }

        public Guid objectGuid { get; set; }

        public string? text { get; set; }

        public GarAddressLevel objectLevel { get; set; }

        public string? objectLevelText { get; set; }
    }
}
