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
    public class WalkDown : AnimatingSprite, IBeetle
    {
        //fields
        private Beetle beetle;
        
        //constructor
        public WalkDown(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.rotation = 0f;
        }

        //update
        public override void Update(GameTime gameTime)
        {
            this.beetle.Position -= new Vector2(0f, this.beetle.Speed);
            if (this.beetle.Position.Y < this.beetle.Top)
            {
                this.beetle.State = this.beetle.WalkUp;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
