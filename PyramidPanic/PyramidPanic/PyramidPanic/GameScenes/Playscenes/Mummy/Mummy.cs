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
    public class Mummy: IAnimatingSprite
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Rectangle rectangle,collisionRec;
        private Vector2 position;
        private float speed;
        private AnimatingSprite state;
        private MummyUp mummyUp;
        private MummyDown mummyDown;
        private MummyRight mummyRight;
        private MummyLeft mummyLeft;
        
        

        //properties
        public MummyLeft MummyLeft
        {
            get { return this.mummyLeft; }
        }
        public MummyRight MummyRight
        {
            get { return this.mummyRight; }
        }
        public MummyUp MummyUp
        {
            get { return this.mummyUp; }
        }
        public MummyDown MummyDown
        {
            get { return this.mummyDown; }
        }

        public AnimatingSprite State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public Rectangle CollisionRec
        {
            get { return this.collisionRec; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                this.rectangle.X = (int)position.X+16;
                this.rectangle.Y = (int)position.Y+16;
                this.collisionRec.X = (int)this.position.X;
                this.collisionRec.Y = (int)this.position.Y;
            }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        //constructor
        public Mummy(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"PlayScene\Badguys\Mummy");
            this.rectangle = new Rectangle((int)position.X + 16, (int)position.Y + 16, this.texture.Width / 4, this.texture.Height);
            this.collisionRec = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            this.speed = speed;
            this.mummyLeft = new MummyLeft(this);
            this.mummyRight = new MummyRight(this);
            this.mummyDown = new MummyDown(this);
            this.mummyUp = new MummyUp(this);
            this.state = new MummyRight(this);
        }

        //update
        public void Update(GameTime gameTime)
        {
            Mummymanager.Mummy = this;
                this.state.Update(gameTime);
                
        }

        //draw
        public void Draw(GameTime gameTime)
        {
           // this.game.SpriteBatch.Draw(this.texture, this.collisionRec, Color.White);
            this.state.Draw(gameTime);
            
        }
    }
}
