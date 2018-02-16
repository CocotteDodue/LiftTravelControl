using LiftTravelControl.Enum;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LiftTravelControl.Extensions
{
    public static class StringExtensions
    {
        public static IList<SummonInformation> ExtractRequests(this string input)
        {
            return JsonConvert.DeserializeObject<IList<SummonInformation>>(input);
        }
    }
}
