using NodaTime;

namespace ChamaeleoIoT
{
    public static class NodaTimeExtensions
    {
        /// <summary>
        /// The instant at the Julian epoch of noon (UTC) January 1st 4713 BCE in the proleptic
        /// Julian calendar, or November 24th 4714 BCE in the proleptic Gregorian calendar.
        /// </summary>
        public static Instant JulianEpoch { get; } = Instant.FromUtc(-4713, 11, 24, 12, 0);

        /// <summary>
        /// Returns the Julian Date of this instance - the number of days since <see
        /// cref="NodaConstants.JulianEpoch"/> (noon on January 1st, 4713 BCE in the Julian calendar).
        /// </summary>
        /// <returns>The number of days (including fractional days) since the Julian Epoch.</returns>
        public static double ToJulianDate(this Instant @this) => (@this - JulianEpoch).ToTimeSpan().TotalDays;
    }
}
