using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Input
{
    class KeyBoardReader : IInputReader
    {
        public static string status="";
        public static string PreviousState = "Right";
        
        public Microsoft.Xna.Framework.Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                status = "Left";
                PreviousState = "Left";
                direction = new Vector2(-1, 0);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                
                status="Right";
                PreviousState = "Right";
                direction = new Vector2(1, 0);
            }
            else
            {
                status = "Idle";
            }
           
            return direction;
        }
    }
}
