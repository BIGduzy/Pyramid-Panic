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
    public class LevelEditorScene : IGameState
    {
        //fields
        private PyramidPanic game;
        private Level level;
        private LevelEditorPanel levelEditorPanel;
        private int levelNumber = 6;
        

        //constructor
        public Level Level
        {
            get { return this.level; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public int LevelNumber
        {
            get { return this.levelNumber; }
            set { this.levelNumber = value; }
        }

        public LevelEditorScene(PyramidPanic game)
        {
            this.game = game;
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
            this.levelEditorPanel = new LevelEditorPanel(this,new Vector2(0f,448f));
            this.loadLevel();
        }

        public void loadLevel()
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
            this.levelEditorPanel.Update(gameTime);
            

        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Gray);
            this.level.Draw(gameTime);
            this.levelEditorPanel.Draw(gameTime);
        }
    }
}
