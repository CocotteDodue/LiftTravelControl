using LiftTravelControl.Enum;
using Newtonsoft.Json;
using Xunit;

namespace LiftTravelControl.Tests
{
    public class TravelDirectionTests
    {
        [Theory]
        [InlineData("\"Up\"", TravelDirection.Up)]
        [InlineData("\"Down\"", TravelDirection.Down)]
        [InlineData("\"None\"", TravelDirection.None)]
        public void TravelDirection_MustWriteValueAsOfItsName_WhenSerialized(string expectedSerializedValue, TravelDirection direction)
        {
            string serializedValue = JsonConvert.SerializeObject(direction);

            Assert.Equal(expectedSerializedValue, serializedValue);
        }
        
        [Theory]
        [InlineData(TravelDirection.Up, "\"Up\"")]
        [InlineData(TravelDirection.Down,"\"Down\"")]
        [InlineData(TravelDirection.None, "\"None\"")]
        public void TravelDirection_MustReadValueFromItsName_WhenDeserialized(TravelDirection expectedDirection, string input)
        {
            TravelDirection direction = JsonConvert.DeserializeObject<TravelDirection>(input);

            Assert.Equal(expectedDirection, direction);

        }
    }
}
