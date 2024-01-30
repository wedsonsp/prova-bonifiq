using System;

namespace ProvaPub.Services
{
    public class RandomService
    {
        private readonly Random _random;
        int seed;
        public RandomService()
        {
            seed = Guid.NewGuid().GetHashCode();
            _random = new Random(seed);
        }
        public int GetRandom()
        {
            //return new Random(seed).Next(100);
            return _random.Next(100);
        }

    }
}