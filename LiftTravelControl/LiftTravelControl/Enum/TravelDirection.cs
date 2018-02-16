using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiftTravelControl.Enum
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TravelDirection
    {
        None,
        Up,
        Down
    }
}
