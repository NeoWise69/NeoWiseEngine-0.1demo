namespace Neowise.Core
{
    public class Random
    {
        private static readonly System.Random random = new System.Random();
        public static int Range (int min, int max)
        {
            return random.Next(min, max);
        }
        public static float Range (float min, float max)
        {
            return random.Next((int)min, (int)max);
        }
        public static int Value()
        {
            return random.Next();
        }
        public static int Value(int max)
        {
            return random.Next(max);
        }
    }
}
