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
    public class PlayerRight:AnimatingSprite
    {
        //fields 
        private Player player;

        //constructor
        public PlayerRight(Player player):base(player)
        {
            this.player = player;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.player.Position += new Vector2(this.player.Speed, 0f);
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
