using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1
{
   public abstract class Component
    { /*Inspiratiebron: O. (2017, 18 juli). MonoGame Tutorial 013 - Game States (Main Menu). YouTube. https://www.youtube.com/watch?v=76Mz7ClJLoE&feature=youtu.be
        Deze was algemeen voor de SceneManager.*/
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
