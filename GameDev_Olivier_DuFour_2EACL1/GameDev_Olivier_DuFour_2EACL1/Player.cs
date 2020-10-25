using GameDev_Olivier_DuFour_2EACL1.Animation;
using GameDev_Olivier_DuFour_2EACL1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1
{
    public class Player:IGameObject
    {
        Texture2D playerTexture;
        Animatie animatie;
       
        public Player(Texture2D text)
        {
            playerTexture = text;
            animatie = new Animatie();
            //Move to the right
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(108, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(216, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(324, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(432, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(540, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(648, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(756, 0, 108, 140)));

            //Move to the left
            //animatie.AddFrame(new AnimationFrame(new Rectangle(0, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(108, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(216, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(324, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(432, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(540, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(648, 140, 108, 140)));
            //animatie.AddFrame(new AnimationFrame(new Rectangle(756, 140, 108, 140)));
        }

        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, new Vector2(10, 10),animatie.CurrentFrame.SourceRectangle , Color.White);
        }

       
    }
}
