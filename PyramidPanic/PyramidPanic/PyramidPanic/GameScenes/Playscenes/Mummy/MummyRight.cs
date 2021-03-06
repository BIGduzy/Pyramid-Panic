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
    public class MummyRight:AnimatingSprite
    {
        //fields 
        private Mummy mummy;
        private bool left, right;
        

        //constructor
        public MummyRight(Mummy mummy) : base(mummy)
        {
            this.mummy = mummy;
            this.rotation = 0f;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position += new Vector2(this.mummy.Speed, 0f);
            if (Mummymanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.mummy.Position.X / 32;
                this.mummy.Position = (this.mummy.Position.X >= 0) ? new Vector2((Geheel) * 32, this.mummy.Position.Y) : new Vector2((Geheel - 1) * 32, this.mummy.Position.Y);
                this.left = Mummymanager.IsThereWallLeftOrRight(0, -1);
                this.right = Mummymanager.IsThereWallLeftOrRight(0, 1);
                if (!this.left && !this.right)
                {
                    switch (Mummymanager.Random.Next(3))
                    {
                        case 0:
                            this.mummy.State = this.mummy.MummyDown;
                            break;

                        case 1:
                            this.mummy.State = this.mummy.MummyUp;
                            break;

                        case 2:
                            this.mummy.State = this.mummy.MummyLeft;
                            break;
                    }
                }
                else if (this.left && !this.right)
                {
                    this.mummy.State = this.mummy.MummyDown;
                }
                else if (this.right && !this.left)
                {
                    this.mummy.State = this.mummy.MummyUp;
                }
                else
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
