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
    class Picture
    {
        //fields
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private PyramidPanic game;

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        //constructor
        public Picture(PyramidPanic game,string pathName,Vector2 position)
        {
            this.position = position;
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(pathName);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y,this.texture.Width,this.texture.Height);
        }

        //Draw
        public void Draw(SpriteBatch spritebatch)
        {
            
            spritebatch.Draw(this.texture, this.rectangle, Color.White);
            
        }

        public void Draw(SpriteBatch spritebatch, Color buttoncolor)
        {
            spritebatch.Draw(this.texture, this.rectangle, buttoncolor);
        }
    }
}
