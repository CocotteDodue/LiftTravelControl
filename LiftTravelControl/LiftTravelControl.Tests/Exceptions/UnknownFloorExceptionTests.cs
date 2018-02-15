using LiftTravelControl.Exceptions;
using System;
using Xunit;

namespace LiftTravelControl.Tests.Exceptions
{
    public class UnknownFloorExceptionTests
    {
        [Fact]
        public void UnknownFloorException_MustBeException()
        {
            Exception ex = new UnknowFloorExecption();

            Assert.NotNull(ex);
        }

        [Fact]
        public void UnknownFloorException_MustProvideExpectedErrorMessage()
        {
            string expectedErrorMessage = "Unknown floor value";
            Exception ex = new UnknowFloorExecption();

            Assert.True(ex.Message.StartsWith(expectedErrorMessage));
        }
    }
}
