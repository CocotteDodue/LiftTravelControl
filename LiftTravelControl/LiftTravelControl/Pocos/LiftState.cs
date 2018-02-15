using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiftTravelControl.Pocos
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiftState
    {
        Travel,
        Parked
    }
}
