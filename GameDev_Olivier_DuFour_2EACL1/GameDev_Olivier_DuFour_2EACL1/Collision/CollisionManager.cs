using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Collision
{
   public class CollisionManager
    {
        public static List<Blok> Wereld = new List<Blok>();
        public static List<Blok> traps = new List<Blok>();
        public static List<Blok> finish = new List<Blok>();
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
            {
                return true;
            }
            return false;
        }

        public bool CheckFuturMovements(Rectangle player)
        {
            foreach (var blok in Wereld)
            {
                if (CheckCollision(player, blok.CollisionRectangle))
                {
                    KeyBoardReader.startY = blok.CollisionRectangle.Y - 140;
                    return true;
                }
                
            }
            return false;
        }
        public bool CheckTrap(Rectangle player)
        {
            foreach (var blok in traps)
            {
                if (CheckCollision(player, blok.CollisionRectangle))
                {
                    KeyBoardReader.startY = blok.CollisionRectangle.Y - 140;
                    return true;
                }

            }
            return false;
        }
        public bool CheckFinish(Rectangle player)
        {
            foreach (var blok in finish)
            {
                if (CheckCollision(player, blok.CollisionRectangle))
                {
                    KeyBoardReader.startY = blok.CollisionRectangle.Y - 140;
                    return true;
                }

            }
            return false;
        }



    }
}
