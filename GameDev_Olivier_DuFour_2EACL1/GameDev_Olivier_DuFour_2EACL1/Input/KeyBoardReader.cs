using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Input
{
    class KeyBoardReader : IInputReader
    {
        public Microsoft.Xna.Framework.Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            }
            return direction;
        }
    }
}
