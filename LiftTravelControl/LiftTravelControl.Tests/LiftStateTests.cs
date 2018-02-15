using LiftTravelControl.Pocos;
using Newtonsoft.Json;
using Xunit;

namespace LiftTravelControl.Tests
{
    public class LiftStateTests
    {
        [Theory]
        [InlineData("\"Parked\"", LiftState.Parked)]
        [InlineData("\"Travel\"", LiftState.Travel)]
        public void LiftState_MustWriteValueAsOfItsName_WhenSerialized(string expectedSerializedValue, LiftState state)
        {
            string serializedValue = JsonConvert.SerializeObject(state);

            Assert.Equal(expectedSerializedValue, serializedValue);
        }
        
        [Theory]
        [InlineData(LiftState.Parked, "\"Parked\"")]
        [InlineData(LiftState.Travel, "\"Travel\"")]
        public void LiftState_MustReadValueFromItsName_WhenDeserialized(LiftState expectedState, string input)
        {
            LiftState state = JsonConvert.DeserializeObject<LiftState>(input);

            Assert.Equal(expectedState, state);

        }
    }
}
