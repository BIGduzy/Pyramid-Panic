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
    public class Player: IAnimatingSprite
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Rectangle rectangle,collisionRec;
        private Vector2 position;
        private float speed;
        private AnimatingSprite state;
        private PlayerUp playerUp;
        private PlayerDown playerDown;
        private PlayerRight playerRight;
        private PlayerLeft playerLeft;
        private PlayerIdle playerIdle;
        //timer
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;
        

        //properties
        public PlayerIdle PlayerIdle
        {
            get { return this.playerIdle; }
        }
        public PlayerLeft PlayerLeft
        {
            get { return this.playerLeft; }
        }
        public PlayerRight PlayerRight
        {
            get { return this.playerRight; }
        }
        public PlayerUp PlayerUp
        {
            get { return this.playerUp; }
        }
        public PlayerDown PlayerDown
        {
            get { return this.playerDown; }
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
        public Player(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"PlayScene\player\Explorer");
            this.rectangle = new Rectangle((int)position.X + 16, (int)position.Y + 16, this.texture.Width / 4, this.texture.Height);
            this.collisionRec = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            this.speed = speed;
            this.playerLeft = new PlayerLeft(this);
            this.playerRight = new PlayerRight(this);
            this.playerDown = new PlayerDown(this);
            this.playerUp = new PlayerUp(this);
            this.playerIdle = new PlayerIdle(this);
            this.state = new PlayerIdle(this,0);
        }

        //update
        public void Update(GameTime gameTime)
        {
           
                this.state.Update(gameTime);
                Playermanager.Player = this;
                Playermanager.CollisionDetectTreasures();
                Playermanager.CollisionDetectScorpions();
                Playermanager.CollisionDetectBeetles();
        }

        //draw
        public void Draw(GameTime gameTime)
        {
           // this.game.SpriteBatch.Draw(this.texture, this.collisionRec, Color.White);
            this.state.Draw(gameTime);
            
        }
    }
}
