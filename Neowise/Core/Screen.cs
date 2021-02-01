using System.Drawing;

namespace Neowise.Core
{
    public class Screen
    {
        private static Size size { get; } = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

        public static Vector2 Size()
        {
            return new Vector2(size.Width, size.Height);
        }
        public static int SizeInt()
        {
            return size.Width * size.Height;
        }
        public static int Width()
        {
            return size.Width;
        }
        public static int Height()
        {
            return size.Height;
        }
        public static float x()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.X;
        }
        public static float y()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y;
        }
    }
}
