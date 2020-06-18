using System;

namespace MapBuilder
{
    class RandomGenerator
    {
        Random _random = new Random();

        public int RandomNumber(int min, int max)
        {
            var number = _random.Next(min, max);
            return number;
        }

        public bool Random01()
        {
            var random = RandomNumber(0, 10);

            return random % 2 == 0;
        }

    }
}
