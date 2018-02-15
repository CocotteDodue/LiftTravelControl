using System;
using Xunit;

namespace LiftTravelControl.Tests
{
    public class ProgramTests
    {
        [Fact]
+        public void Program_MustThrowExecption_WhenCurrentParkedFloorValueNotRecievedAtStart()
+        {
+            Assert.Throws<ArgumentException>(() => Program.Main(null));
+        }
}
}
