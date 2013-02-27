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
        private bool left, right;

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
                this.left = Mummymanager.IsThereWallLeftOrRight(0, 1);
                this.right = Mummymanager.IsThereWallLeftOrRight(0, -1);
                if (!this.left && !this.right)
                {
                    //Console.WriteLine("Er zijn geen muren" + MummyManager.Random.Next(2));
                    switch (Mummymanager.Random.Next(3))
                    {
                        case 0:
                            this.mummy.State = new MummyDown(this.mummy);
                            break;
                        case 1:
                            this.mummy.State = new MummyUp(this.mummy);
                            break;
                        case 2:
                            this.mummy.State = new MummyRight(this.mummy);
                            break;
                        default:
                            break;
                    }
                }
                else if (this.left && !this.right)
                {
                    //Console.WriteLine("Er is links een muur ik ga rechtsaf");
                    mummy.State = new MummyUp(this.mummy);
                }
                else if (this.right && !this.left)
                {
                    //Console.WriteLine("Er is rechts een muur ik ga linksaf");
                    mummy.State = new MummyDown(this.mummy);
                }
                else
                {
                    //Console.WriteLine("Links en rechts zijn er muren ik ga terug");
                    mummy.State = new MummyRight(this.mummy);
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
