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
    public class Beetle : IAnimatingSprite
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle,collisionrec;
        private IBeetle state;
        private float speed;
        private float top,bot;
        private WalkDown walkDown;
        private WalkUp walkUp;
       
       
        //properties
        public WalkUp WalkUp
        {
            get { return this.walkUp; }
        }

        public WalkDown WalkDown
        {
            get { return this.walkDown; }
        }

        public float Top
        {
            get { return this.top; }
            set { this.top = value; }
        }
        public float Bot
        {
            get { return this.bot; }
            set { this.bot = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set 
            {
                this.position = value;
                this.rectangle.X = (int)this.position.X +16;
                this.rectangle.Y = (int)this.position.Y + 16;
                this.collisionrec.X = (int)this.position.X;
                this.collisionrec.Y = (int)this.position.Y;
            }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        public PyramidPanic Game
        {
            get {return this.game;}
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public Rectangle Rectangle
        {
            get {return this.rectangle;}
        }
        public Rectangle Collisionrec
        {
            get { return this.collisionrec; }
        }

        public IBeetle State
        {
            get { return this.state;}
            set { this.state = value;}
        }

        //constructor
        public Beetle(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Badguys\Beetle");
            this.rectangle = new Rectangle((int)this.position.X + 16,(int)this.position.Y + 16,this.texture.Width/4,this.texture.Height);
            this.collisionrec = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.speed = speed;
            this.walkUp = new WalkUp(this);
            this.walkDown = new WalkDown(this);
            this.state = new WalkDown(this);

        }

        //update
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
