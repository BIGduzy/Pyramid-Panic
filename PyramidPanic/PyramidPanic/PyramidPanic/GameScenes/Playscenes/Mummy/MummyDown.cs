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
    public class MummyDown:AnimatingSprite
    {
        //fields 
        private Mummy mummy;

        //constructor
        public MummyDown(Mummy mummy):base(mummy)
        {
            this.mummy = mummy;
            this.rotation = (float)Math.PI/2;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position += new Vector2(0f,this.mummy.Speed);
            if (Mummymanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.mummy.Position.Y / 32;
                this.mummy.Position = (this.mummy.Position.Y >= 0) ? new Vector2(this.mummy.Position.X, Geheel * 32) : new Vector2(this.mummy.Position.X, (Geheel - 1) * 32);
                if (Input.DetectKeyUp(Keys.S))
                {
                    this.mummy.State = this.mummy.MummyLeft;
                }
            }

            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
