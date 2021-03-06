﻿using GameDev_Olivier_DuFour_2EACL1.Frames;
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
        private FramesPlayer Frames;
        public AnimatiePlayer(FramesPlayer frames)
        {
            this.Frames = frames;
        }
        public override void Update(GameTime gameTime)
        {
            /* De idle naar left blijft wanner we terug naar links begeven*/
            if (KeyBoardReader.status==statussen.Left)
            {
                WalkLeft(gameTime);
            }
            else if(KeyBoardReader.status ==statussen.Right)
            {
                WalkRight(gameTime);
            }
            else if (KeyBoardReader.status== statussen.Idle)
            {
                if (KeyBoardReader.PreviousState==statussen.Left)
                {
                    IdleLeft();
                }
                else
                {
                    IdleRight();
                } 
            }
        }
        public void WalkLeft(GameTime gameTime)
        {
            CurrentFrame = Frames.framesWalkLeft[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.SourceRectangle.Width / 10)
            {
                counter++;
                frameMovement = 0;
            }


            if (counter >= Frames.framesWalkLeft.Count)
            {
                counter = 0;
            }
        }
        public void WalkRight(GameTime gameTime)
        {
            CurrentFrame = Frames.framesWalkRight[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.SourceRectangle.Width / 10)
            {
                counter++;
                frameMovement = 0;
            }
            if (counter >= Frames.framesWalkRight.Count)
            {
                counter = 0;
            }
        }
        public void IdleLeft()
        {
            CurrentFrame = Frames.framesIdleLeft[0];
        }
        public void IdleRight()
        {
            CurrentFrame = Frames.framesIdleRight[0];
        }
    }
}
