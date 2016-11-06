using System;
using NodaTime;

namespace ChamaeleoIoT
{
    public class DaylightService : IDaylightService
    {
        public ZonedDateTime GetSunrise(ZonedDateTime date, Coordinates location)
        {
            return this.CalculateSunrise(true, date, location, date.Zone);
        }

        public ZonedDateTime GetSunset(ZonedDateTime date, Coordinates location)
        {
            return this.CalculateSunrise(false, date, location, date.Zone);
        }

        private double CalculateDeclinationOfSun(double eclipticLongitude) => Math.Sin(eclipticLongitude.ToRadians()) * Math.Sin(23.44.ToRadians());

        private double CalculateEclipticLongitude(double solarMeanAnomaly, double center) => (solarMeanAnomaly + center + 180 + 102.9372) % 360;

        private double CalculateEquationOfTheCenter(double solarMeanAnomaly)
        {
            var radMeanAnomaly = solarMeanAnomaly.ToRadians();

            return 1.9148 * Math.Sin(radMeanAnomaly) + 0.0200 * Math.Sin(2 * radMeanAnomaly) + 0.0003 * Math.Sin(3 * radMeanAnomaly);
        }

        private double CalculateHourAngle(double latitude, double sunDeclination)
        {
            double latRadians = latitude.ToRadians();

            double cosSunDeclination = Math.Sqrt(1d - sunDeclination * sunDeclination);

            double cos = (Math.Sin(-0.83.ToRadians()) - Math.Sin(latRadians) * sunDeclination) / (Math.Cos(latRadians) * cosSunDeclination);

            return Math.Acos(cos).ToDegrees();
        }

        private double CalculateMeanSolarNoon(double julianDate, double longitude) => julianDate - (longitude / 360);

        private double CalculateSolarMeanAnomaly(double meanSolarNoon) => (357.5291 + 0.98560028 * meanSolarNoon) % 360;

        private double CalculateSolarTransit(double julianDate, double solarMeanAnomaly, double eclipticLongitude)
        {
            var radMeanAnomaly = solarMeanAnomaly.ToRadians();
            var radEclipticLongitude = eclipticLongitude.ToRadians();

            return 2451545.5 + julianDate + 0.0053 * Math.Sin(radMeanAnomaly) - 0.0069 * Math.Sin(2 * radEclipticLongitude);
        }

        private ZonedDateTime CalculateSunrise(bool isSunrise, ZonedDateTime date, Coordinates location, DateTimeZone timeZone)
        {
            double julianDate = date.Date.AtMidnight().InUtc().ToInstant().ToJulianDate();

            double days = julianDate - 2451545.0d + 0.0008d;

            double meanSolarNoon = this.CalculateMeanSolarNoon(days, location.Longitude);

            double solarMeanAnomaly = this.CalculateSolarMeanAnomaly(meanSolarNoon);

            double center = this.CalculateEquationOfTheCenter(solarMeanAnomaly);

            double eclipticLongitude = this.CalculateEclipticLongitude(solarMeanAnomaly, center);

            double solarTransit = this.CalculateSolarTransit(meanSolarNoon, solarMeanAnomaly, eclipticLongitude);

            double sunDeclination = this.CalculateDeclinationOfSun(eclipticLongitude);

            double hourAngle = this.CalculateHourAngle(location.Latitude, sunDeclination);

            double adjustment = hourAngle / 360d;

            double julianSunDate = (isSunrise ? -1 : 1) * adjustment + solarTransit;

            Instant gregorianInstant = Instant.FromJulianDate(julianSunDate);

            return new ZonedDateTime(gregorianInstant, timeZone);
        }
    }
}
