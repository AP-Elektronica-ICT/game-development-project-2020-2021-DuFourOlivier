using GameDev_Olivier_DuFour_2EACL1.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Frames
{

    public class FramesPlayer
    {
        public List<AnimationFrame> framesWalkRight;
        public List<AnimationFrame> framesWalkLeft;
        public List<AnimationFrame> framesIdleRight;
        public List<AnimationFrame> framesIdleLeft;
        public FramesPlayer()
        {
            framesWalkRight = new List<AnimationFrame>();
            framesWalkLeft = new List<AnimationFrame>();
            framesIdleRight = new List<AnimationFrame>();
            framesIdleLeft = new List<AnimationFrame>();
            framesWalkRight = new List<AnimationFrame>();
            framesWalkLeft = new List<AnimationFrame>();
            framesIdleRight = new List<AnimationFrame>();
            framesIdleLeft = new List<AnimationFrame>();
            //Naar links
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(756, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(648, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(540, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(432, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(324, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(216, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(108, 140, 108, 140)));
            AddFrameWalkLeft(new AnimationFrame(new Rectangle(0, 140, 108, 140)));
            //NAar rechts
            AddFrameWalkRight(new AnimationFrame(new Rectangle(0, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(108, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(216, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(324, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(432, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(540, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(648, 0, 108, 140)));
            AddFrameWalkRight(new AnimationFrame(new Rectangle(756, 0, 108, 140)));
            //IdleRight
            AddFrameIdleRight(new AnimationFrame(new Rectangle(0, 0, 108, 140)));
            //IdleLeft
            AddFrameIdleLeft(new AnimationFrame(new Rectangle(756, 140, 108, 140)));
        }
  
    private void AddFrameWalkRight(AnimationFrame animationFrame)
    {
        framesWalkRight.Add(animationFrame);

    }
        private void AddFrameWalkLeft(AnimationFrame animationFrame)
    {
        framesWalkLeft.Add(animationFrame);

    }
        private void AddFrameIdleLeft(AnimationFrame animationFrame)
    {
        framesIdleLeft.Add(animationFrame);

    }
        private void AddFrameIdleRight(AnimationFrame animationFrame)
    {
        framesIdleRight.Add(animationFrame);

    }
}
}
