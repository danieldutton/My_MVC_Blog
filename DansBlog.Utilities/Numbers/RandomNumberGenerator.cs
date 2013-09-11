using DansBlog.Utilities.Interfaces;
using System;

namespace DansBlog.Utilities.Numbers
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GetRandomNumber(int min, int max)
        {
            var random = new Random();

            return random.Next(min, max);
        }
    }
}
