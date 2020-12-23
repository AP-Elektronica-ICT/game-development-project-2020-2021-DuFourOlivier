using GameDev_Olivier_DuFour_2EACL1.Collision;
using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.Interfaces;
using GameDev_Olivier_DuFour_2EACL1.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Commands
{
   public class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        CollisionManager collisionManager = new CollisionManager();
 
        public MoveCommand()
        {
            
            this.speed = new Vector2(4, 2);
        }
        public void Execute(ITransform transform, Vector2 direction, Player player)
        {
            direction *= speed;
            Rectangle futureX = new Rectangle((int)(player.Position.X + direction.X),(int)(player.Position.Y), player.CollisionRectangle.Width, player.CollisionRectangle.Height);
            Rectangle futureY = new Rectangle((int)(player.Position.X), (int)(player.Position.Y + direction.Y), player.CollisionRectangle.Width, player.CollisionRectangle.Height);
            if (!collisionManager.CheckFuturMovements(futureX))
            {
                
                transform.Position += new Vector2(direction.X,0);
            }
            if (!(collisionManager.CheckFuturMovements(futureY)))
            {
                KeyBoardReader.startY = 820;
                if (KeyBoardReader.jumping==false && player.Position.Y<=KeyBoardReader.startY)
                //If it's farther than ground
                {
                    Debug.WriteLine("vallen");
                    KeyBoardReader.jumping = true;
                    KeyBoardReader.jumpspeed = 1;
                    
                }


                transform.Position += new Vector2(0, direction.Y);
            }
            if ((collisionManager.CheckFuturMovements(futureY)))
            {
                KeyBoardReader.jumping = false;
               
            }

            Debug.WriteLine(direction);
        }
    }
}
