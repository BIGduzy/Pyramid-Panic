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
    public class MummyUp:AnimatingSprite
    {
        //fields 
        private Mummy mummy;
        private bool left, right;

        //constructor
        public MummyUp(Mummy mummy)  : base(mummy)
        {
            this.mummy = mummy;
            this.rotation = (float)Math.PI*(float)1.5;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position -= new Vector2(0f,this.mummy.Speed);
            if (Mummymanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.mummy.Position.Y / 32;
                this.mummy.Position = new Vector2(this.mummy.Position.X, (Geheel + 1) * 32);
                this.left = Mummymanager.IsThereWallLeftOrRight(-1, 0);
                this.right = Mummymanager.IsThereWallLeftOrRight(1, 0);
                if (!this.left && !this.right)
                {
                    // Console.WriteLine("Er zijn geen muren" + Mummymanager.Random.Next(2));
                    switch (Mummymanager.Random.Next(3))
                    {
                        case 0:
                            this.mummy.State = new MummyRight(this.mummy);
                            break;
                        case 1:
                            this.mummy.State = new MummyDown(this.mummy);
                            break;
                        case 2:
                            this.mummy.State = new MummyLeft(this.mummy);
                            break;
                        default:
                            break;
                    }
                }
                else if (this.left && !this.right)
                {
                    //Console.WriteLine("Er is links een muur ik ga rechtsaf");
                    mummy.State = new MummyRight(this.mummy);
                }
                else if (this.right && !this.left)
                {
                    //Console.WriteLine("Er is rechts een muur ik ga linksaf");
                    mummy.State = new MummyLeft(this.mummy);
                }
                else
                {
                    //Console.WriteLine("Links en rechts zijn er muren ik ga terug");
                    mummy.State = new MummyDown(this.mummy);
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
