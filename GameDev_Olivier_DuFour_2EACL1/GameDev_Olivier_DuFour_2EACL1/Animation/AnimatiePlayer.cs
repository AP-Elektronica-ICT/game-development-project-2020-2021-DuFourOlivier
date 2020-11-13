using GameDev_Olivier_DuFour_2EACL1.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Animation
{
   public class AnimatiePlayer: Animation
    {
        
        private List<AnimationFrame> framesWalkRight;
        private List<AnimationFrame> framesWalkLeft;
        private List<AnimationFrame> framesIdleLeft;
        private List<AnimationFrame> framesIdleRight;
        
        
       
        public AnimatiePlayer()
        {
            framesWalkRight = new List<AnimationFrame>();
            framesWalkLeft = new List<AnimationFrame>();
            framesIdleRight = new List<AnimationFrame>();
            framesIdleLeft = new List<AnimationFrame>();
            counter = 0;
            frameMovement = 0;
        }

        public void AddFrameWalkRight(AnimationFrame animationFrame)
        {
            framesWalkRight.Add(animationFrame);
            
        }
        public void AddFrameWalkLeft(AnimationFrame animationFrame)
        {
            framesWalkLeft.Add(animationFrame);
            
        }
        public void AddFrameIdleLeft(AnimationFrame animationFrame)
        {
            framesIdleLeft.Add(animationFrame);
            
        }
        public void AddFrameIdleRight(AnimationFrame animationFrame)
        {
            framesIdleRight.Add(animationFrame);
            
        }

        public override void Update(GameTime gameTime)
        {
            /* De idle naar left blijft wanner we terug naar links begeven*/
            if (KeyBoardReader.WalkLeft==true)
            {
                CurrentFrame = framesWalkLeft[counter];

                frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
                if (frameMovement >= CurrentFrame.SourceRectangle.Width / 10)
                {
                    counter++;
                    frameMovement = 0;
                }


                if (counter >= framesWalkLeft.Count)
                {
                    counter = 0;
                }
            }
             if(KeyBoardReader.WalkLeft == false)
            {
            CurrentFrame = framesWalkRight[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement>= CurrentFrame.SourceRectangle.Width/10)
            {
                counter++;
                frameMovement = 0;
            }
            

            if (counter >= framesWalkRight.Count)
            {
                counter = 0;
            }
            }
            if (KeyBoardReader.Idle==true)
            {
                if (KeyBoardReader.PreviousState==true)
                {
                    CurrentFrame = framesIdleLeft[0];
                }
                else
                {
                    CurrentFrame = framesIdleRight[0];
                }
                
                
            }
            
            
                
            
            

        }
    }
}
