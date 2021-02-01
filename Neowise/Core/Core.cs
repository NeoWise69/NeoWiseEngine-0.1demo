using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Neowise.Core
{
    public abstract class Core
    {
        public Color backGroundColor;
        public Vector2 cameraPosition = Vector2.Zero();
        public float cameraRotateAngle = 0f;
        public float cameraZoom = 1f;

        public static List<Shape2D> shapeList = new List<Shape2D>();
        public static List<Sprite2D> spriteList = new List<Sprite2D>();
        
        private Vector2 screenSize = new Vector2(640, 480);
        private string title = "New game";
        private Canvas window = null;
        private Thread LoopThread = null;

        public Core (Vector2 screenSize, string title)
        {
            Debug.Log("Game starts...");

            this.screenSize = screenSize;
            this.title = title;

            window = new Canvas();
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            window.Text = this.title;
            

            window.Paint += Renderer;
            window.FormClosing += Window_FormClosing;

            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;


            LoopThread = new Thread(GameLoop);
            LoopThread.Start();


            Application.Run(window);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnDisable();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        public static void AddShape (Shape2D shape)
        {
            shapeList.Add(shape);
        }
        public static void AddSprite (Sprite2D sprite)
        {
            spriteList.Add(sprite);
        }
        public static void RemoveSprite (Sprite2D sprite)
        {
            spriteList.Remove(sprite);
        }
        public static void RemoveShape (Shape2D shape)
        {
            shapeList.Remove(shape);
        }

        void GameLoop()
        {
            OnLoad();
            while (LoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });

                    OnUpdate();
                    Thread.Sleep(2);
                }
                catch
                {
                    Debug.LogError("Game window is closed!!!");
                }
            }
        }
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(backGroundColor);
            g.TranslateTransform(cameraPosition.x, cameraPosition.y);
            g.RotateTransform(cameraRotateAngle);
            g.ScaleTransform(cameraZoom, cameraZoom);

            try
            {
                foreach (Shape2D shape in shapeList)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
                }
            }
            catch
            {
                Debug.LogWarning("Loading shape-list data...");
            } // Shape2D render

            try
            {
                foreach  (Sprite2D sprite in spriteList)
                {
                    if (!sprite.IsReference)
                    {
                        g.DrawImage(sprite.Sprite, sprite.position.x, sprite.position.y, sprite.scale.x, sprite.scale.y);
                    }
                }
            }
            catch
            {
                Debug.LogWarning("Loading sprite-list data...");
            } // Sprite2D render
        }

        public abstract void OnLoad();
        public abstract void OnDraw();
        public abstract void OnUpdate();
        public abstract void OnDisable();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
