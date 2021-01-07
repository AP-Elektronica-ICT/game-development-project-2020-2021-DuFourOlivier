using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1
{
    public class PlayerPosition
    {
        public List<Vector2> Postions = new List<Vector2>();
        public PlayerPosition()
        {
            Postions.Add(new Vector2(120, 820));
            Postions.Add(new Vector2(1500, 800));
        }
    }
}
