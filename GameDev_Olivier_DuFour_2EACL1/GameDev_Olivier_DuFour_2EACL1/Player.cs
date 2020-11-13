using GameDev_Olivier_DuFour_2EACL1.Animation;
using GameDev_Olivier_DuFour_2EACL1.Commands;
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
    public class Player:IGameObject, ITransform
    {
       private Texture2D playerTexture;
       private AnimatiePlayer animatie;
       private IInputReader inputReader;
       private IGameCommand moveCommand;

        public Vector2 Position { get ; set ; }

        public Player(Texture2D text, IInputReader reader)
        {
            playerTexture = text;
            animatie = new AnimatiePlayer();
            //naar links
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(756, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(648, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(540, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(432, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(324, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(216, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(108, 140, 108, 140)));
            animatie.AddFrameWalkLeft(new AnimationFrame(new Rectangle(0, 140, 108, 140)));

            
            //NAar rechts
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(0, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(108, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(216, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(324, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(432, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(540, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(648, 0, 108, 140)));
            animatie.AddFrameWalkRight(new AnimationFrame(new Rectangle(756, 0, 108, 140)));
            //IdleRight
            animatie.AddFrameIdleRight(new AnimationFrame(new Rectangle(0, 0, 108, 140)));

            //IdleLeft
            animatie.AddFrameIdleLeft(new AnimationFrame(new Rectangle(756, 140, 108, 140)));


            Position = new Vector2(10, 365);
            this.inputReader = reader;
            moveCommand = new MoveCommand();
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            Move(direction);
            animatie.Update(gameTime);
        }

        private void Move(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, Position,animatie.CurrentFrame.SourceRectangle , Color.White);
        }

       
    }
}
