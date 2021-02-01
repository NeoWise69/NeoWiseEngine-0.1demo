using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neowise.Core
{
    public class Sprite2D
    {
        public Vector2 position { get; set; }
        public Vector2 scale { get; set; }
        public string directory = "";
        public string tag = "";
        public Bitmap Sprite = null;
        public bool IsReference = false;

        public Sprite2D(Vector2 position, Vector2 scale, string tag, string directory)
        {
            this.position = position;
            this.scale = scale;
            this.directory = directory;
            this.tag = tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;

            Debug.LogTechniq($"[SPRITE2D] {this.tag} - Has been loaded!");

            Core.AddSprite(this);
        }
        public Sprite2D(string directory)
        {
            this.directory = directory;
            this.IsReference = true;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;

            Debug.LogTechniq($"[SPRITE2D] {this.tag} - Has been loaded!");

            Core.AddSprite(this);
        }

        public Sprite2D(Vector2 position, Vector2 scale, string tag, Sprite2D reference)
        {
            this.tag = tag;

            this.position = position;
            this.scale = scale;

            Sprite = reference.Sprite;

            Debug.LogTechniq($"[SPRITE2D] {this.tag} - Has been loaded!");

            Core.AddSprite(this);
        }

        public bool IsColliding (Sprite2D a, Sprite2D b)
        {
            if (a.position.x < b.position.x + b.scale.x &&
                a.position.x + a.scale.x > b.position.x &&
                a.position.y < b.position.y + b.scale.y &&
                a.position.y + a.scale.y > b.position.y)
            {
                return true;
            }
            return false;
        }
        public Sprite2D IsColliding (string tag)
        {
            foreach (Sprite2D b in Core.spriteList)
            {
                if (b.tag == tag)
                {
                    if (position.x < b.position.x + b.scale.x &&
                        position.x + scale.x > b.position.x &&
                        position.y < b.position.y + b.scale.y &&
                        position.y + scale.y > b.position.y)
                    {
                        return b;
                    }
                }
            }
            return null;
        }
        public void Destroy()
        {
            Core.RemoveSprite(this);
            Debug.LogTechniq($"[SPRITE2D] {tag} - Has been unloaded!");
        }



    }
}
