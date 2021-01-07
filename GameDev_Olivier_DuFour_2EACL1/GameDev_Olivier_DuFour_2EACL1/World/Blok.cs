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


        public Blok(Rectangle rec)
        {
            CollisionRectangle = rec;
        }

        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(_texture, Position,DeelRectangle, Color.AliceBlue);
        //}

        public void Update()
        {

        }
    }
}
