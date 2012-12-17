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
    public class PlayerIdle : AnimatingSprite
    {
        //fields 
        private Player player;

        //properties

        //constructor
        public PlayerIdle(Player player): base(player)
        {
            this.player = player;
            this.i = 1;
        }

        public PlayerIdle(Player player, float rotation): base(player)
        {
            this.player = player;
            this.rotation = rotation;
            this.i = 1;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            if (Input.DetectKeyDown(Keys.D))
            {
                this.player.State = this.player.PlayerRight;
            }
            if (Input.DetectKeyDown(Keys.A))
            {
                this.player.State = this.player.PlayerLeft;
            }
            if (Input.DetectKeyDown(Keys.W))
            {
                this.player.State = this.player.PlayerUp;
            }
            if (Input.DetectKeyDown(Keys.S))
            {
                this.player.State = this.player.PlayerDown;
            }
            //base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
