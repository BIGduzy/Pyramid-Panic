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
    public class MummyLeft:AnimatingSprite
    {
        //fields 
        private Mummy mummy;

        //constructor
        public MummyLeft(Mummy mummy):base(mummy)
        {
            this.mummy = mummy;
            this.rotation = (float)Math.PI;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position -= new Vector2(this.mummy.Speed, 0f);
            if (Mummymanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.mummy.Position.X / 32;
                this.mummy.Position = new Vector2((Geheel +1) * 32, this.mummy.Position.Y);
                    this.mummy.State = this.mummy.MummyDown;
                
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
