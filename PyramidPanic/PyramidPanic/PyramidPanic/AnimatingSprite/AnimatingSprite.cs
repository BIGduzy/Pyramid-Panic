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
    public class AnimatingSprite
    {
        //fields
        private Beetle beetle;
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;
        protected float rotation;


        //constructor
       public AnimatingSprite(Beetle beetle)
        {
            this.beetle = beetle;
            this.rotation = (float)Math.PI;
            
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Console.WriteLine(this.timer);
            if (this.timer > 1f / 10f)
            {
                this.timer = 0;
                this.i++;
                if (i > 2)
                {
                    this.i = 0;
                }

            }
        }

        public void Draw(GameTime gameTime)
        {
            this.beetle.Game.SpriteBatch.Draw(this.beetle.Texture, this.beetle.Rectangle, new Rectangle(this.xValue[this.i], 0, 32, 32),
                                            Color.White, this.rotation, new Vector2(16f, 16f), SpriteEffects.None, 0);

           
        }
    }
}
