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
    public class HelpScene : IGameState
    {
        //fields
        private PyramidPanic game;
        private Picture background;
        private Texture2D text, marker1, marker2;
        private Rectangle rectangle1, rectangle2;
        private Vector2 position;
        //constructor
        public HelpScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Picture(this.game, @"PlayScene/Background/Background2", Vector2.Zero);
            this.text = game.Content.Load<Texture2D>(@"Help/help");
            this.marker1 = game.Content.Load<Texture2D>(@"Help/marker");
            this.marker2 = game.Content.Load<Texture2D>(@"Help/marker");
            this.rectangle1 = new Rectangle(300, 0, 40, 40);
            this.rectangle2 = new Rectangle(295, 420, 40, 40);
            this.position = Vector2.Zero;
            this.Initialize();
        }

        //initialize
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

            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (this.position.Y >= 0)
            {
                this.position.Y = 0;
            }
            if (this.position.Y <= -300)
            {
                this.position.Y = -300;
            }
            if (Input.MouseRec().Intersects(rectangle1))
            {
                this.position.Y += 2;
            }

            if (Input.MouseRec().Intersects(rectangle2))
            {
                this.position.Y -= 2;
            }
        }
        //draw
        public void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.DarkGoldenrod);
            this.background.Draw(gameTime);
            this.game.SpriteBatch.Draw(this.text, this.position, Color.White);
            this.game.SpriteBatch.Draw(this.marker1, this.rectangle1,null,Color.White,(float)Math.PI*(float)1.5,new Vector2(45f,0f),SpriteEffects.None,0);
            this.game.SpriteBatch.Draw(this.marker2, this.rectangle2, null, Color.White, (float)Math.PI * (float)00.5, new Vector2(10f, 50f), SpriteEffects.None, 0);
            
        }
    }
}