namespace Neowise.Core
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2()
        {
            x = Zero().x;
            y = Zero().y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Возвращает значения вектора равные нулю.
        /// Returns x and y equals to 0.
        /// </summary>
        /// <returns></returns>
        public static Vector2 Zero()
        {
            return new Vector2(0f, 0f);
        }
    }
}
