using NodaTime;
using NUnit.Framework;
using static ChamaeleoIoT.Tests.TestConstants;

namespace ChamaeleoIoT.Tests
{
    [TestFixture]
    public class DaylightServiceTests : BaseTestFixture<DaylightService, DaylightServiceTests.TestEnvironment>
    {
        [Test]
        [TestCase(1970, 4, 13, 5, 57, 18, 47, 29.7604, -95.3698, "America/Chicago")]
        [TestCase(1957, 10, 4, 7, 49, 19, 23, 45.9203, 63.3422, "Asia/Almaty")]
        [TestCase(2000, 9, 15, 6, 56, 18, 47, -33.84722, 151.06333, "Australia/Sydney")]
        [TestCase(2016, 11, 8, 7, 49, 17, 21, 48.8566, 2.3522, "Europe/Paris")]
        public void GetSunrise_GetSunset_WithVariousParameters_ReturnsExpectedSunriseTime(int year, int month, int day, int expectedSunriseHour, int expectedSunriseMinutes, int expectedSunsetHour, int expectedSunsetMinutes, double latitude, double longitude, string timeZone)
        {
            var subject = this.GetEnvironment().Subject;

            var date = new LocalDateTime(year, month, day, 0, 0).InZoneStrictly(DateTimeZoneProviders.Tzdb.GetZoneOrNull(timeZone));
            var location = new Coordinates(latitude, longitude);

            var sunrise = subject.GetSunrise(date, location);
            var sunset = subject.GetSunset(date, location);

            var expectedSunrise = date.PlusHours(expectedSunriseHour).PlusMinutes(expectedSunriseMinutes);
            var expectedSunset = date.PlusHours(expectedSunsetHour).PlusMinutes(expectedSunsetMinutes);

            Assert.That(sunrise.ToInstant().ToUnixTimeSeconds(), Is.EqualTo(expectedSunrise.ToInstant().ToUnixTimeSeconds()).Within(60), "Expected sunrise {0}, received {1}", expectedSunrise, sunrise);
            Assert.That(sunset.ToInstant().ToUnixTimeSeconds(), Is.EqualTo(expectedSunset.ToInstant().ToUnixTimeSeconds()).Within(60), "Expected sunset {0}, received {1}", expectedSunset, sunset);
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