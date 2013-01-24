﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class LevelNextLevel : ILevel
    {
        //Fields
        private Level level;
        private Picture gameOver;
        private int pauseTimeOver = 2;
        private float timer = 0;

        //Constructor
        public LevelNextLevel(Level level)
        {
            this.level = level;
            this.gameOver = new Picture(level.Game, @"PlayScene\Overlay\LevelNextLevel", Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                
                if (PlayScene.LevelNumber == 10)
                {
                    this.level.LevelState = new LevelEndGame(level);
                }
                else
                {
                    Score.MinPointsLevel += 500;
                    PlayScene.LevelNumber++;
                    level.Game.GameState = new PlayScene(level.Game);
                    this.timer = 0;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.gameOver.Draw(gameTime);
        }
    }
}