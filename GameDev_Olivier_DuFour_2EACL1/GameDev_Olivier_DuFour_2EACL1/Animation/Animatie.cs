using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Animation
{
   public class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        

        public void Update()
        {

        }
    }
}
