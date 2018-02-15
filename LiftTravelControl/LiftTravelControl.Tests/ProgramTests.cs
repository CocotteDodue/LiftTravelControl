
using LiftTravelControl.Exceptions;
using System;
using Xunit;

namespace LiftTravelControl.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Program_MustThrowExecption_WhenCurrentParkedFloorValueNotRecievedAtStart()
        {
            Assert.Throws<ArgumentException>(() => Program.Main(null));
        }

        [Theory]
        [InlineData("Foo")]
        [InlineData("7.5")]
        [InlineData("")]
        public void Program_MustThrowExecption_WhenCurrentParkedFloorValueParameterNotInteger(string testValue)
        {
            Assert.Throws<ArgumentException>(() => Program.Main(new[] { testValue }));
        }

        [Theory]
        [InlineData("-2")]
        [InlineData("11")]
        [InlineData("145")]
        public void Program_MustThrowExecption_WhenCurrentParkedFloorValueParameterNotIn1To10Range(string testValue)
        {
            Assert.Throws<UnknowFloorExecption>(() => Program.Main(new[] { testValue }));
        }
    }
}
