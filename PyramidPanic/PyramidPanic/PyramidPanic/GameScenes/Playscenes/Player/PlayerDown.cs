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
    public class PlayerDown:AnimatingSprite
    {
        //fields 
        private Player player;

        //constructor
        public PlayerDown(Player player):base(player)
        {
            this.player = player;
            this.rotation = (float)Math.PI/2;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.player.Position += new Vector2(0f,this.player.Speed);

            if (Input.DetectKeyUp(Keys.S))
            {
                float modulo = this.player.Position.Y % 32;

                if (modulo >= (32f - this.player.Speed))
                {
                    int Geheel = (int)this.player.Position.Y / 32;
                    this.player.Position = new Vector2(this.player.Position.X, (Geheel + 1) * 32);
                    this.player.State = new PlayerIdle(this.player, (float)Math.PI / 2);
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
