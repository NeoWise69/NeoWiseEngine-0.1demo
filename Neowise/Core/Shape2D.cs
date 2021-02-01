namespace Neowise.Core
{
    public class Shape2D
    {
        public Vector2 position { get; set; }
        public Vector2 scale { get; set; }
        public string tag = "";

        public Shape2D (Vector2 position, Vector2 scale, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.tag = tag;
            Debug.LogTechniq($"[SHAPE2D] {tag} - Has been spawned!");
            Core.AddShape(this);
        }

        public bool IsColliding(Shape2D a, Shape2D b)
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

        public Shape2D IsColliding(string tag)
        {
            foreach (Shape2D b in Core.shapeList)
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
            Core.RemoveShape(this);
            Debug.LogTechniq($"[SHAPE2D] {tag} - Has been destroyed!");
        }
    }
}
