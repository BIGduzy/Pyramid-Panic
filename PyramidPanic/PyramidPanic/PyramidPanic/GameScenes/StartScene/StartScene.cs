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
    public class StartScene : IGameState
    {
        //fields
        private Picture background, title;
        private PyramidPanic game;
        private MenuStartScene menu;


        //constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Picture(game, "TitleScherm\\Background", Vector2.Zero);
            this.title = new Picture(game, "TitleScherm\\Title",new Vector2(100f,30f));
            this.menu = new MenuStartScene(game);

        }

        //Initialize
        public void Initialize()
        {

        }

        //loadContent
        public void LoadContent()
        {

        }
        //update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.Exit();
            }
            this.menu.Update(gameTime);
        }
        //draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(this.game.SpriteBatch);
            this.title.Draw(this.game.SpriteBatch);
            this.menu.Draw(gameTime);
        }
    }
}
