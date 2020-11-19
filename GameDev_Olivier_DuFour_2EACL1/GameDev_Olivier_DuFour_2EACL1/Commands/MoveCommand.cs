using GameDev_Olivier_DuFour_2EACL1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Commands
{
   public class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        public MoveCommand()
        {
            this.speed = new Vector2(4, 2);
        }
        public void Execute(ITransform transform, Vector2 direcrtion)
        {
            direcrtion *= speed;
            transform.Position += direcrtion;
        }
    }
}
