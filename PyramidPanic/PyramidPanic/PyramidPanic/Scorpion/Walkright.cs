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
    public class WalkRight : IScorpion
    {
        //fields
        private Scorpion scorpion;
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;
        


        //constructor
        public WalkRight(Scorpion scorpion)
        {
            this.scorpion = scorpion;
        }

        //update
        public void Update(GameTime gameTime)
        {
            this.scorpion.Position += new Vector2(this.scorpion.Speed, 0f);
            if (this.scorpion.Position.X > 564)
            {
                this.scorpion.State = new WalkLeft(this.scorpion);
            }
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
            this.scorpion.Game.SpriteBatch.Draw(this.scorpion.Texture, this.scorpion.Rectangle, new Rectangle(this.xValue[this.i], 0, 32, 32),
                                            Color.White, 0f, new Vector2(16f,16f), SpriteEffects.None, 0);
        }
    }
}
