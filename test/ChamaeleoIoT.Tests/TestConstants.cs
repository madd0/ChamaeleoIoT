using NodaTime;

namespace ChamaeleoIoT.Tests
{
    public static class TestConstants
    {
        public const double JulianNow = 2456540.05156;

        static TestConstants()
        {
            Today = new ZonedDateTime(Now, TestTimeZone);

            SunriseToday = new ZonedDateTime(SunriseInstant, TestTimeZone);

            SunsetToday = new ZonedDateTime(SunsetInstant, TestTimeZone);
        }

        public static Instant Now { get; } = Instant.FromUtc(2013, 9, 4, 13, 14, 15);

        public static Instant SunriseInstant { get; } = Instant.FromUtc(2013, 9, 4, 7, 13, 0);

        public static ZonedDateTime SunriseToday { get; }

        public static Instant SunsetInstant { get; } = Instant.FromUtc(2013, 9, 4, 20, 28, 0);

        public static ZonedDateTime SunsetToday { get; }

        public static DateTimeZone TestTimeZone { get; } = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Paris");

        public static ZonedDateTime Today { get; }
    }
}
