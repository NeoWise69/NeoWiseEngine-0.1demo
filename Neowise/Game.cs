using Neowise.Core;
using System.Drawing;

namespace Neowise
{
    class Game : Core.Core
    {
        Sprite2D player;

        int tileSize = 32;

        bool left = false;
        bool up = false;
        bool right = false;
        bool down = false;
        bool shift = false;

        float acceleration = 1f;
        Vector2 lastPos = Vector2.Zero();


        string[,] map =
        {
            {"w","w","w","w","w","w","w","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","w","w","w","w","=","w","w", },
            {"w","w","w","w","w","=","w","w", },
            {"w","w","w","w","w","=","w","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","w","=","w","w","w","w","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
            {"w","=","=","=","=","=","=","w", },
        };

        public Game() : base(new Vector2(Screen.Width() / 2f, Screen.Height() / 2f), "Test game") { }

        public override void OnLoad()
        {
            backGroundColor = Color.Gray;

            Sprite2D wallRef = new Sprite2D("d_wall");

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int t = 0; t < map.GetLength(0); t++)
                {
                    if (map[t, i] == "w")
                    {
                        new Sprite2D(new Vector2(i * tileSize, t * tileSize), new Vector2(tileSize, tileSize), "Wall", wallRef);
                    }
                }
            }

            player = new Sprite2D(new Vector2(40, 40), new Vector2(25, 25), "Player", "d_player");
        }

        public override void OnDraw()
        {
            cameraZoom = 2f;
        }
        public override void OnUpdate()
        {
            #region Movement
            if (up)
            {
                player.position.y -= .1f * acceleration;
            }
            if (left)
            {
                player.position.x -= .1f * acceleration;
            }
            if (down)
            {
                player.position.y += .1f * acceleration;
            }
            if (right)
            {
                player.position.x += .1f * acceleration;
            }
            if (shift)
            {
                acceleration = 5f;
            }
            if (!shift)
            {
                acceleration = 2f;
            }
            #endregion
            Sprite2D wall = player.IsColliding("Wall");
            if (wall != null)
            {
                player.position.x = lastPos.x;
                player.position.y = lastPos.y;
            }
            else
            {
                cameraPosition.x = -player.position.x * 2 + Screen.Width() * 0.25f;
                cameraPosition.y = -player.position.y * 2 + Screen.Height() * 0.25f;
                lastPos.x = player.position.x;
                lastPos.y = player.position.y;
            }

        }

        public override void GetKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            #region Movement
            if (e.KeyCode == System.Windows.Forms.Keys.W || e.KeyCode == System.Windows.Forms.Keys.Up) { up = true; }
            if(e.KeyCode == System.Windows.Forms.Keys.A || e.KeyCode == System.Windows.Forms.Keys.Left) { left = true; }
            if(e.KeyCode == System.Windows.Forms.Keys.S || e.KeyCode == System.Windows.Forms.Keys.Down) { down = true; }
            if(e.KeyCode == System.Windows.Forms.Keys.D || e.KeyCode == System.Windows.Forms.Keys.Right) { right = true; }
            if(e.KeyCode == System.Windows.Forms.Keys.ShiftKey) { shift = true; }
            #endregion

            Debug.Log($"Player position:{player.position.x} x {player.position.y}");
        }

        public override void GetKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            #region Movement
            if (e.KeyCode == System.Windows.Forms.Keys.W || e.KeyCode == System.Windows.Forms.Keys.Up) { up = false; }
            if (e.KeyCode == System.Windows.Forms.Keys.A || e.KeyCode == System.Windows.Forms.Keys.Left) { left = false; }
            if (e.KeyCode == System.Windows.Forms.Keys.S || e.KeyCode == System.Windows.Forms.Keys.Down) { down = false; }
            if (e.KeyCode == System.Windows.Forms.Keys.D || e.KeyCode == System.Windows.Forms.Keys.Right) { right = false; }
            if (e.KeyCode == System.Windows.Forms.Keys.ShiftKey) { shift = false; ; }
            #endregion

        }

        public override void OnDisable()
        {
            spriteList.Clear();
            shapeList.Clear();
            player = null;
        }
    }
}
