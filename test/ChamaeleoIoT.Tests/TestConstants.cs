using NodaTime;

namespace ChamaeleoIoT.Tests
{
    public static class TestConstants
    {
        public const double JulianNow = 2456540.05156;

        static TestConstants()
        {
            Today = new ZonedDateTime(Now, TestTimeZone);

            SunriseToday = TestTimeZone.AtStrictly(new LocalDateTime(2013, 9, 4, 7, 12));

            SunsetToday = TestTimeZone.AtStrictly(new LocalDateTime(2013, 9, 4, 20, 29));
        }

        public static Coordinates Here { get; } = new Coordinates(48.8566, 2.3522);

        public static Instant Now { get; } = Instant.FromUtc(2013, 9, 4, 13, 14, 15);

        public static ZonedDateTime SunriseToday { get; }

        public static ZonedDateTime SunsetToday { get; }

        public static DateTimeZone TestTimeZone { get; } = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Paris");

        public static ZonedDateTime Today { get; }
    }
}
