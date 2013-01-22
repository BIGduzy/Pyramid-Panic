using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PlayScene : IGameState
    {
        //fields
        private PyramidPanic game;
        private Level level;
        private int levelNumber = 1;
        private static int endLevel = 10;


        //constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            if (levelNumber == 0 || Score.isDead())
            {
                levelNumber = 0;
                Score.Initialize();
            }   
            this.Initialize();
        }


        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //loadContent
        public void LoadContent()
        {
            this.level = new Level(this.game, this.levelNumber);
        }

        //update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (Score.isDead())
            {
                this.level.LevelState = level.LevelGameOver;
            }
            if (Playermanager.WalkOutOfLevel())
            {
                Score.DoorsAreClosed = true;
                levelNumber++;
                this.level.Player.Position = new Vector2(100f, 100f);
                if (levelNumber == endLevel)
                {
                    this.level.LevelState = new LevelEndGame(this.level);
                    levelNumber = 0;
                }
                else
                {
                    this.level.LevelState = level.LevelNextLevel;
                }
            }
            this.level.Update(gameTime);


        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            this.level.Draw(gameTime);
        }
    }
}
