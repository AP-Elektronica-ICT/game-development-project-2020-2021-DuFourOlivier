using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Input
{
    class KeyBoardReader : IInputReader
    {
        public static string status= "Idle";
        public static string PreviousState = "Idle";
        bool jumping; //Is the character jumping?
        float startY, jumpspeed = 0; //startY to tell us //where it lands, jumpspeed to see how fast it jumps

        public KeyBoardReader()
        {
            jumping = false;//Init jumping to false
            jumpspeed = 0;//Default no speed
            startY = 335;
        }
        public Microsoft.Xna.Framework.Vector2 ReadInput(Player player)
        {
            var direction = Vector2.Zero;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                status = "Left";
                PreviousState = "Left";
                direction = new Vector2(-2, 0);

                if (jumping)
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
                        jumpspeed = -14;//Give it upward thrust
                        player.Position = new Vector2(player.Position.X, startY);



                    }
                }
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                
                status="Right";
                PreviousState = "Right";
                direction = new Vector2(2,0);
                 if (jumping)
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
                        status = "Idle";
                        PreviousState = "Right";
                        jumping = true;
                        jumpspeed = -14;//Give it upward thrust
                        player.Position = new Vector2(player.Position.X, startY);



                    }
                }
            }
           
            else if (jumping)
            {
                //status = "Idle";
                
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
            //else if (!jumping)
            //{
            //    if (state.IsKeyDown(Keys.Space))
            //    {

            //        jumping = true;
            //        jumpspeed = -14;//Give it upward thrust
            //        player.Position = new Vector2(player.Position.X, startY);



            //    }
            //}
            else
            {
                status = "Idle";
            }
           
            return direction;
        }
        //public Microsoft.Xna.Framework.Vector2 Jump(Player player, bool jump)
        //{

        //}
    }
}
