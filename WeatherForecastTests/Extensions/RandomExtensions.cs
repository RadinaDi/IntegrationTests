using System;
using System.Linq;

namespace WeatherForecastTests.Extensions
{
    public static class RandomExtensions
    {
        private const string Charset = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string NextString(this Random random, int fixedLength = -1, int minLength = 1, int maxLength = 1000)
        {
            fixedLength = (fixedLength == -1) ? random.Next(minLength, maxLength) : fixedLength;
            var chars = Enumerable.Repeat(Charset, fixedLength).Select(s => s[random.Next(s.Length)]).ToArray();
            return new string(chars);
        }
    }
}
