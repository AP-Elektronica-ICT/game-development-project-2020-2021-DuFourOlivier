using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Input
{
    class KeyBoardReader : IInputReader
    {
        public static bool WalkLeft=false;
        public static bool Idle=false;
        public static bool PreviousState = false;
        
        public Microsoft.Xna.Framework.Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                WalkLeft = true;
                Idle = false;
                PreviousState = true;
                direction = new Vector2(-1, 0);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                
                Idle = false;
                WalkLeft = false;
                PreviousState = false;
                direction = new Vector2(1, 0);
            }
            else
            {

               Idle = true;
               
                
            }
           
            return direction;
        }
    }
}
