using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameDev_Olivier_DuFour_2EACL1.Controls;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;

namespace GameDev_Olivier_DuFour_2EACL1.States
{
    public class MenuState : State
    { /*Inspiratiebron: O. (2017, 18 juli). MonoGame Tutorial 013 - Game States (Main Menu). YouTube. https://www.youtube.com/watch?v=76Mz7ClJLoE&feature=youtu.be 
         Deze was algemeen voor de SceneManager.
        Inspiratiebron voor muziek: Hawkes, C. (2014, 27 september). MonoGame - How to play background music in MonoGame. YouTube. https://www.youtube.com/watch?v=Vw-UCTLhIFw&feature=youtu.be */
        private List<Component> _components;
        private Texture2D backgroundScreen;
        private Song introSong;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            MediaPlayer.Stop();
            var buttonTexture = _content.Load<Texture2D>("Controls/ThrButton");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font1");
            backgroundScreen = _content.Load<Texture2D>("StartScherm");
            introSong = _content.Load<Song>("Songs/Menu");
            MediaPlayer.Play(introSong);
            var Level1Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 450),
                Text = "Level 1",
            };
            Level1Button.Click += Level1Button_Click;
            var Level2Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 550),
                Text = "Level 2",
            };
            Level2Button.Click += Level2Button_Click;
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 650),
                Text = "Quit Game",
            };
            quitGameButton.Click += QuitGameButton_Click;
            _components = new List<Component>()
      {
        Level1Button,
        Level2Button,
        quitGameButton,
      };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundScreen, new Rectangle(0, 0, 1600, 960), Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
        private void Level2Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Level 2");
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content,2));
        }
        private void Level1Button_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
