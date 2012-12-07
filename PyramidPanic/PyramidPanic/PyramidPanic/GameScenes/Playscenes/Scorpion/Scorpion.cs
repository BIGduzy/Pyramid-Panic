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
    public class Scorpion : IAnimatingSprite
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private IScorpion state;
        private float speed;
        private float right, left;
       
       
        //properties
        public float Right
        {
            get { return this.right; }
            set { this.right = value; }
        }
        public float Left
        {
            get { return this.left; }
            set { this.left = value; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set 
            {
                this.position = value;
                this.rectangle.X = (int)this.position.X +16;
                this.rectangle.Y = (int)this.position.Y +16;
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

        public IScorpion State
        {
            get { return this.state;}
            set { this.state = value;}
        }

        //constructor
        public Scorpion(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Badguys\Scorpion");
            this.rectangle = new Rectangle((int)this.position.X,(int)this.position.Y,this.texture.Width/4,this.texture.Height);
            this.state = new WalkRight(this);
            this.speed = speed;

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
