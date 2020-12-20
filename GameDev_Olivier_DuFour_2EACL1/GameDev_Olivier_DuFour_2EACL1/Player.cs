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
using System.Diagnostics;
using GameDev_Olivier_DuFour_2EACL1.Frames;
using GameDev_Olivier_DuFour_2EACL1.World;

namespace GameDev_Olivier_DuFour_2EACL1
{
    public class Player:IGameObject, ITransform
    {
       private Texture2D playerTexture;
       private AnimatiePlayer animatie;
       private FramesPlayer frames;
       private IInputReader inputReader;
       private IGameCommand moveCommand;
       public Rectangle CollisionRectangle { get; set; }
       private Rectangle _collisionRectangle;
        private Blok blokje;

        public Vector2 Position { get ; set ; }

        public Player(Texture2D text, IInputReader reader)
        {
            
            frames = new FramesPlayer();
            playerTexture = text;
            animatie = new AnimatiePlayer(frames);
            Position = new Vector2(10, 365);
            this.inputReader = reader;
            moveCommand = new MoveCommand();

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 80, 120);
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput(this);
            Debug.WriteLine(direction);
            Move(direction);
            animatie.Update(gameTime);
            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;
            CollisionRectangle = _collisionRectangle;
            Debug.WriteLine(CollisionRectangle);
        }

        private void Move(Vector2 direction)
        {
            moveCommand.Execute(this, direction,this);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, Position,animatie.CurrentFrame.SourceRectangle , Color.White);
            
            
        }

       
    }
}
