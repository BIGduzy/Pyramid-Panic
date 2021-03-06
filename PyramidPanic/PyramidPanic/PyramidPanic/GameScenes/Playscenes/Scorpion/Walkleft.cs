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
    public class WalkLeft : AnimatingSprite, IScorpion
    {
        //fields
        private Scorpion scorpion;
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;


        //constructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.rotation = (float)Math.PI;
        }

        //update
        public override void Update(GameTime gameTime)
        {
            this.scorpion.Position -= new Vector2(this.scorpion.Speed, 0f);
            if (this.scorpion.Position.X < scorpion.Left)
            {
                this.scorpion.State = this.scorpion.WalkRight;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
