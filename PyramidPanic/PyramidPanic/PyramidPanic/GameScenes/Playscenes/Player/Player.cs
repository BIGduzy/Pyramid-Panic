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
    public class Player: IAnimatingSprite
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private float speed;
        private AnimatingSprite state;
        //timer
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;
        

        //properties
        public AnimatingSprite State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value;
                this.rectangle.X = (int)position.X+16;
                this.rectangle.Y = (int)position.Y+16; }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        //constructor
        public Player(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\player\Explorer");
            this.rectangle = new Rectangle((int)position.X+16, (int)position.Y+16, this.texture.Width/4, this.texture.Height);
            this.speed = speed;

            this.state = new PlayerIdle(this);
        }

        public void Update(GameTime gameTime)
        {
           
                this.state.Update(gameTime);
        }

        //draw
        public void Draw(GameTime gameTime)
        {
            
            this.state.Draw(gameTime);
        }
    }
}