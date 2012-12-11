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
    public class PlayerUp:AnimatingSprite
    {
        //fields 
        private Player player;

        //constructor
        public PlayerUp(Player player):base(player)
        {
            this.player = player;
            this.rotation = (float)Math.PI*(float)1.5;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.player.Position -= new Vector2(0f,this.player.Speed);

            if (Input.DetectKeyUp(Keys.W))
            {
                this.player.State = new PlayerIdle(this.player);
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
