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
using GameDev_Olivier_DuFour_2EACL1.States;

namespace GameDev_Olivier_DuFour_2EACL1.SceneManager.States
{
    public class DeathState : State
    {
        private List<Component> _components;
        private Texture2D backgroundScreen;
        public DeathState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/ThrButton");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font1");
            backgroundScreen = _content.Load<Texture2D>("GameOver");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 450),
                Text = "Main Menu",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 550),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
      {
        newGameButton,
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


        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("clicked");
            _game.Exit();

        }
    }
}

