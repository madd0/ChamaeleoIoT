using NUnit.Framework;
using static ChamaeleoIoT.Tests.TestConstants;

namespace ChamaeleoIoT.Tests
{
    [TestFixture]
    public class DaylightServiceTests : BaseTestFixture<DaylightService, DaylightServiceTests.TestEnvironment>
    {
        [Test]
        [TestCase(1970, 4, 13, 5, 57, 18, 46, 29.7604, -95.3698, "America/New_York")]
        [TestCase(1957, 10, 4, 6, 19, 17, 47, 45.920278, 63.342222, "Asia/Almaty")]
        [TestCase(2000, 9, 15, 6, 53, 18, 47, -33.84722, 151.06333, "Australia/Sydney")]
        public void GetSunrise_GetSunset_WithVariousParameters_ReturnsExpectedSunriseTime(int year, int month, int day, int expectedSunriseHour, int expectedSunriseMinutes, int expectedSunsetHour, int expectedSunsetMinutes, double longitude, double latitude, string timeZone)
        {
            var subject = this.GetEnvironment().Subject;

            var sunrise = subject.GetSunrise(Today, Here);

            Assert.That(sunrise.ToInstant().ToUnixTimeSeconds(), Is.EqualTo(SunriseToday.ToInstant().ToUnixTimeSeconds()).Within(60));
        }

        [Test]
        public void GetSunrise_WithValidParameters_ReturnsExpectedSunriseTime()
        {
            var subject = this.GetEnvironment().Subject;

            var sunrise = subject.GetSunrise(Today, Here);

            Assert.That(sunrise.ToInstant().ToUnixTimeSeconds(), Is.EqualTo(SunriseToday.ToInstant().ToUnixTimeSeconds()).Within(60));
        }

        [Test]
        public void GetSunset_WithValidParameters_ReturnsExpectedSunriseTime()
        {
            var subject = this.GetEnvironment().Subject;

            var sunset = subject.GetSunset(Today, Here);

            Assert.That(sunset.ToInstant().ToUnixTimeSeconds(), Is.EqualTo(SunsetToday.ToInstant().ToUnixTimeSeconds()).Within(60));
        }

        public class TestEnvironment : TestEnvironment<DaylightService>
        {
            protected override void OnSetupEnvironment()
            {
            }
        }
    }
}
