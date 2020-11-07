using GameDev_Olivier_DuFour_2EACL1.Animation;
using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_Olivier_DuFour_2EACL1
{
    public class Player:IGameObject
    {
        Texture2D playerTexture;
        Animatie animatie;
        public Vector2 positie;
        public Vector2 snelheid;
        IInputReader inputReader;
       
        public Player(Texture2D text, IInputReader reader)
        {
            playerTexture = text;
            animatie = new Animatie();
            
            //if (MoveLeft==true)
            //{
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(0, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(108, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(216, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(324, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(432, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(540, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(648, 140, 108, 140)));
            //    animatie.AddFrame(new AnimationFrame(new Rectangle(756, 140, 108, 140)));
            //}
            //else
            //{

            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(108, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(216, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(324, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(432, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(540, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(648, 0, 108, 140)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(756, 0, 108, 140)));

            //}
            
            positie = new Vector2(10, 365);
            snelheid = new Vector2(1, 1);
            this.inputReader = reader;



        }

        public void Update(GameTime gameTime)
        {


            var direction = inputReader.ReadInput();
            direction *= 4;
            positie += direction;
            animatie.Update(gameTime);
        }

        private void Move()
        {
            positie = positie + snelheid;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, positie,animatie.CurrentFrame.SourceRectangle , Color.White);
        }

       
    }
}
