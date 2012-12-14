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
    public enum BlockColision {Pas,Npas};
    public class Block
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private char charItem;
        private BlockColision blockColision;

        //properties
        public BlockColision BlockColision
        {
            get { return this.blockColision; }
        }

        public Rectangle Rectangle
        {
            get {return this.rectangle ;}
        }


        //constructor
        public Block(PyramidPanic game,string blockName, Vector2 position, BlockColision blockColision, char charItem)
        {
            this.game = game;
            
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Blocks\"+blockName);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, this.texture.Width, this.texture.Height);
            this.position = position;
            this.charItem = charItem;
            this.blockColision = blockColision;
        }

        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture,this.position,Color.White);
        }

    }
}
