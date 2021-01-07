using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev_Olivier_DuFour_2EACL1.Collision;
using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace GameDev_Olivier_DuFour_2EACL1.States
{
    public class GameState : State
    {
        // Tilesharp
        TmxMap map;
        Texture2D tileset;

        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;
        //
        Rectangle bounds;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture, blokTexture;
        Player player;
        Blok blok;
        CollisionManager collisionManager;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            collisionManager = new CollisionManager();
            bounds = new Rectangle(0, 0, 0, 0);
            LoadContent();
            
        }
        public  void LoadContent()
        {
            // Load content for player, map
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            texture = _content.Load<Texture2D>("character");
            blokTexture = _content.Load<Texture2D>("blok");
            InitializeGameObjects();
            // gamestate
           

            // load map + tileset
            map = new TmxMap("Content/Level1Complete.tmx");
            tileset = _content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            foreach (var p in map.ObjectGroups[0].Objects)
            {
                CollisionManager.Wereld.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));
            }
            foreach (var p in map.ObjectGroups[2].Objects)
            {
                CollisionManager.traps.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
            foreach (var p in map.ObjectGroups[1].Objects)
            {
                CollisionManager.finish.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
        }
        private void InitializeGameObjects()
        {
            //foreach (var o in map.ObjectGroups[0].Objects)
            //{
            //    CollisionManager.Wereld.Add(new Blok(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height)));
            //}

            //CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(150, 400)));
            //CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(250, 350)));
            //CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(350, 300)));
            //CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(450, 350)));
            //CollisionManager.Wereld.Add(new Blok(blokTexture, new Vector2(550, 400)));

            player = new Player(texture, new KeyBoardReader());
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            // Draw Map
            for (var j = 0; j < map.Layers.Count; j++)
            {

                for (var i = 0; i < map.Layers[j].Tiles.Count; i++)
                {
                    int gid = map.Layers[j].Tiles[i].Gid;

                    // Empty tile, do nothing
                    if (gid == 0)
                    {

                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                        float x = (i % map.Width) * map.TileWidth;
                        float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);


                        Rectangle newView = new Rectangle((int)x + bounds.X, (int)y + bounds.Y, tileWidth, tileHeight);
                        _spriteBatch.Draw(tileset, newView, tilesetRec, Color.White);
                    }
                }
            }
            // draw player

            player.Draw(_spriteBatch);
            //foreach (var blok in CollisionManager.Wereld)
            //{
            //    blok.Draw(_spriteBatch);
            //}


            _spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
    }
}
