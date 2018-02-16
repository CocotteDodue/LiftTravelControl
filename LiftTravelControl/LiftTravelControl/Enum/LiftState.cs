using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiftTravelControl.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiftState
    {
        Travel,
        Parked
    }
}
