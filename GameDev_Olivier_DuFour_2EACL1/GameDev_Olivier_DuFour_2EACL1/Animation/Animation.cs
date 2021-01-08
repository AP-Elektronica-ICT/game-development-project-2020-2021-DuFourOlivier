using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Animation
{
   public abstract class Animation
    {
            public AnimationFrame CurrentFrame { get; set; }
            public int counter;
            public double frameMovement;
            public abstract void Update(GameTime gameTime);
    }
}
