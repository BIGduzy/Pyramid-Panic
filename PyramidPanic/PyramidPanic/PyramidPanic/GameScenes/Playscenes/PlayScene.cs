﻿using System;
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

        //constructor
        public PlayScene(PyramidPanic game)
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

        }

        //update
        public void Update(GameTime gameTime)
        {

        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.DarkGoldenrod);
        }
    }
}
