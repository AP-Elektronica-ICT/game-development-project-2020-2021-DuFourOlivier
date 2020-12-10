using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Input
{
    public enum statussen {Left,Idle,Right,Jumping,NotJumping }
    public enum CollisionPlayer {YES,NO}
    class KeyBoardReader : IInputReader
    {
        public static statussen PreviousState = statussen.Right;
        public static statussen status = statussen.Idle;
        public static CollisionPlayer ColPlayer = CollisionPlayer.NO;
        KeyboardState state;
        public static bool jumping; //Is the character jumping?
        public static float startY, jumpspeed = 0; //startY to tell us //where it lands, jumpspeed to see how fast it jumps

        public KeyBoardReader()
        {
            
            jumping = false;//Init jumping to false
            jumpspeed = 0;//Default no speed
            startY = 365;
        }
        public Microsoft.Xna.Framework.Vector2 ReadInput(Player player)
        {
            var direction = Vector2.Zero;
            state = Keyboard.GetState();
            lookdirection(status);

            return new Vector2(MoveHorizontal(state).X, MoveVertical(state, player).Y);
        }
        private Microsoft.Xna.Framework.Vector2 MoveHorizontal(KeyboardState key)
        {
            var direction = Vector2.Zero;
            key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Left))
            {
                status = statussen.Left;
                direction = new Vector2(-2, 0);
            }
            else if (key.IsKeyDown(Keys.Right))
            {
                status = statussen.Right;
                direction = new Vector2(2, 0);
            }
            else
            {
                status = statussen.Idle;
            }
            return direction;
        }
        private Microsoft.Xna.Framework.Vector2 MoveVertical(KeyboardState key, Player player)
        {
            var direction = Vector2.Zero;
            if (jumping==true)
            {
                
                direction.Y += jumpspeed;

                jumpspeed += 0.5f;//Some math (explained later)
                if (player.Position.Y > startY)
                //If it's farther than ground
                {
                    Debug.WriteLine(jumping);
                    jumping = false;
                    direction.Y = 0;
                }
            }
            else if (!jumping)
            {
                
                if (state.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -8;//Give it upward thrust
                    player.Position = new Vector2(player.Position.X, startY);
                }
                else
                {
                    Debug.WriteLine(jumping);
                    direction.Y = 0;
                }
            }
            return direction;
        }
        private void lookdirection(statussen look)
        {

            switch (look)
            {
                case statussen.Left:
                    PreviousState = statussen.Left;
                    break;
                case statussen.Right:
                    PreviousState = statussen.Right;
                    break;
                default:
                    break;
            }

        }
        //private void StatePicker()
        //{
        //    if (status != CharState.jumping)
        //    {
        //        if (HorizontalMovement.X != 0)
        //        {
        //            status = CharState.run;
        //        }
        //        else
        //        {
        //            status = CharState.idle;
        //        }
        //    }


        }
}
