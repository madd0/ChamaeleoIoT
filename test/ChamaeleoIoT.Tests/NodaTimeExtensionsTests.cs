using NUnit.Framework;
using static ChamaeleoIoT.Tests.TestConstants;

namespace ChamaeleoIoT.Tests
{
    [TestFixture]
    public class NodaTimeExtensionsTests
    {
        [Test]
        public void Instant_ToJulianDate_WithValidParameters_ReturnsJulianDate()
        {
            var jd = Now.ToJulianDate();

            Assert.That(jd, Is.EqualTo(JulianNow).Within(0.001).Percent);
        }
    }
}
