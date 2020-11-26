using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.World
{
    public class Blok
    {
        public Texture2D _texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle DeelRectangle;


        public Blok(Texture2D texture, Vector2 pos)
        {
            DeelRectangle = new Rectangle(0, 0, 80, 80);
            _texture = texture;
            Position = pos;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 80, 80);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position,DeelRectangle, Color.AliceBlue);
        }

        public void Update()
        {

        }
    }
}
