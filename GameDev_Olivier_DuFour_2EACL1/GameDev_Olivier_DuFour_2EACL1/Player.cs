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
