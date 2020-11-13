using GameDev_Olivier_DuFour_2EACL1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1.Commands
{
    public interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direcrtion);
    }
}
