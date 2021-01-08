using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Olivier_DuFour_2EACL1.States
{
    public abstract class State
    { /*Inspiratiebron: O. (2017, 18 juli). MonoGame Tutorial 013 - Game States (Main Menu). YouTube. https://www.youtube.com/watch?v=76Mz7ClJLoE&feature=youtu.be 
         Deze was algemeen voor de SceneManager.*/
        #region Fields
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;
        #endregion
        #region Methods
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }
        public abstract void Update(GameTime gameTime);
        #endregion
    }
}
