using GameDev_Olivier_DuFour_2EACL1.Collision;
using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameDev_Olivier_DuFour_2EACL1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture, blokTexture;
        Player player;
        Blok blok;
        CollisionManager collisionManager;
       
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("character");
            blokTexture = Content.Load<Texture2D>("blok");
            InitializeGameObjects();

            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObjects()
        {
            CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(150, 400)));
            CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(250, 350)));
            CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(350, 300)));
            CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(450, 350)));
            CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(550, 400)));
            
            player = new Player(texture, new KeyBoardReader(),blok);
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);


            //if (collisionManager.CheckCollision(player.CollisionRectangle, blok.CollisionRectangle))
            //{
            //    Debug.WriteLine("Collision");
            //}
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            foreach (var blok in CollisionManager.Wereld)
            {
                blok.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
