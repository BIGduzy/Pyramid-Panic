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
    public abstract class AnimatingSprite
    {
        //fields
        private IAnimatingSprite animatingSprite;
        private int[] xValue = { 0, 32, 64, 96 };
        protected int i = 0;
        private float timer;
         float rotation;


        //constructor
       public AnimatingSprite(IAnimatingSprite animatingSprite)
        {
            this.animatingSprite = animatingSprite;
            this.rotation = 0f;
        }


        //Update
        public virtual void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
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

        public virtual void Draw(GameTime gameTime)
        {
            this.animatingSprite.Game.SpriteBatch.Draw(this.animatingSprite.Texture, this.animatingSprite.Rectangle, new Rectangle(this.xValue[this.i], 0, 32, 32),
                                            Color.White, this.rotation, new Vector2(16f, 16f), SpriteEffects.None, 0);

           
        }
    }
}
