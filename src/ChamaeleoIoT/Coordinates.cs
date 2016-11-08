using System;

namespace ChamaeleoIoT
{
    public struct Coordinates
    {
        private readonly double _latitude;
        private readonly double _longitude;

        public Coordinates(double latitude, double longitude)
        {
            if (longitude > 180 || longitude < -180)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be in range [-180; 180].");
            }

            if (latitude > 90 || latitude < -90)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be in range [-90; 90].");
            }

            _latitude = latitude;
            _longitude = longitude;
        }

        public double Latitude
        {
            get
            {
                return _latitude;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
        }
    }
}
