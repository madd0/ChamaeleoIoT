using System;

namespace ChamaeleoIoT
{
    public static class DoubleExtensions
    {
        public static double ToDegrees(this double radians) => radians * 180d / Math.PI;

        public static double ToRadians(this double degrees) => degrees * Math.PI / 180d;
    }
}
