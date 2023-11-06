using System.Text.Json.Serialization;

namespace Delivery.Api
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,
        Female
    }
}
