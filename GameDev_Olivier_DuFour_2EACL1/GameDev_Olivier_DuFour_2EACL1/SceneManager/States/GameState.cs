using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev_Olivier_DuFour_2EACL1.Collision;
using GameDev_Olivier_DuFour_2EACL1.Input;
using GameDev_Olivier_DuFour_2EACL1.SceneManager.States;
using GameDev_Olivier_DuFour_2EACL1.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace GameDev_Olivier_DuFour_2EACL1.States
{ /*Inspiratiebron: O. (2017, 18 juli). MonoGame Tutorial 013 - Game States (Main Menu). YouTube. https://www.youtube.com/watch?v=76Mz7ClJLoE&feature=youtu.be 
     Deze was algemeen voor de SceneManager.
    Inspiratiebron voor TiledSharp: Lioncat Dev Studio. (2020, 9 oktober). Loading Tile maps monogame 3.8 and TiledSharp. YouTube. https://www.youtube.com/watch?v=iwc7COCLhkA&feature=youtu.be */
    public class GameState : State
    {
        // Tilesharp
        private List<TmxMap> map;
        private Texture2D tileset;
        public static int level;
        private int tileWidth;
        private int tileHeight;
        private int tilesetTilesWide;
        private int tilesetTilesHigh;
        private Rectangle bounds;
        private SpriteBatch _spriteBatch;
        private Texture2D texture, blokTexture;
        private Player player;
        private CollisionManager collisionManager;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int levelinput = 1)
          : base(game, graphicsDevice, content)
        {
            collisionManager = new CollisionManager();
            bounds = new Rectangle(0, 0, 0, 0);
            map = new List<TmxMap>();
            level = levelinput - 1;
            LoadContent();
        }
        public  void LoadContent()
        {
            // Load content for player, map
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            texture = _content.Load<Texture2D>("character");
            blokTexture = _content.Load<Texture2D>("blok");
            InitializeGameObjects();
            // load map + tileset
            map.Add(new TmxMap("Content/Level1Complete.tmx"));
            map.Add(new TmxMap("Content/Level2Complete.tmx"));
            tileset = _content.Load<Texture2D>(map[level].Tilesets[0].Name.ToString());
            tileWidth = map[level].Tilesets[0].TileWidth;
            tileHeight = map[level].Tilesets[0].TileHeight;
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
            foreach (var p in map[level].ObjectGroups[0].Objects)
            {
                CollisionManager.Wereld.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));
            }
            foreach (var p in map[level].ObjectGroups[2].Objects)
            {
                CollisionManager.traps.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
            foreach (var p in map[level].ObjectGroups[1].Objects)
            {
                CollisionManager.finish.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
        }
        private void InitializeGameObjects()
        {
            player = new Player(texture, new KeyBoardReader());
        }
        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            // Draw Map
            for (var j = 0; j < map[level].Layers.Count; j++)
            {
                for (var i = 0; i < map[level].Layers[j].Tiles.Count; i++)
                {
                    int gid = map[level].Layers[j].Tiles[i].Gid;
                    // Empty tile, do nothing
                    if (gid == 0)
                    {
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                        float x = (i % map[level].Width) * map[level].TileWidth;
                        float y = (float)Math.Floor(i / (double)map[level].Width) * map[level].TileHeight;
                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);
                        Rectangle newView = new Rectangle((int)x + bounds.X, (int)y + bounds.Y, tileWidth, tileHeight);
                        _spriteBatch.Draw(tileset, newView, tilesetRec, Color.White);
                    }
                }
            }
            // draw player
            player.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            CollisionManager.Wereld.Clear();
            CollisionManager.traps.Clear();
            CollisionManager.finish.Clear();
            foreach (var p in map[level].ObjectGroups[0].Objects)
            {
                CollisionManager.Wereld.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));
            }
            foreach (var p in map[level].ObjectGroups[2].Objects)
            {
                CollisionManager.traps.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
            foreach (var p in map[level].ObjectGroups[1].Objects)
            {
                CollisionManager.finish.Add(new Blok(new Rectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height)));

            }
            player.Update(gameTime);
            if (collisionManager.CheckFinish(player.CollisionRectangle))
            {
                if (level < map.Count - 1)
                {
                    level = level + 2;
                    _game.ChangeState(new GameState(_game, _graphicsDevice, _content, level));
                                   }
                else if (level == map.Count -1 )
                {
                    _game.ChangeState(new VictoryState(_game, _graphicsDevice, _content));
                }
            }
            else if (collisionManager.CheckTrap(player.CollisionRectangle))
            {
                _game.ChangeState(new DeathState(_game, _graphicsDevice, _content));
            }

        }
    }
}
