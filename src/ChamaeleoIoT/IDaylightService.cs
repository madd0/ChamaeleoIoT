using NodaTime;

namespace ChamaeleoIoT
{
    public interface IDaylightService
    {
        ZonedDateTime GetSunrise(ZonedDateTime date, Coordinates location);

        ZonedDateTime GetSunset(ZonedDateTime date, Coordinates location);
    }
}
