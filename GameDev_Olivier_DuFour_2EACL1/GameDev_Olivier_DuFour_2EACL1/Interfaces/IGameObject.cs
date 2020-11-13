using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Interfaces
{
   public interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
    }
}
