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
    public class PlayerLeft:AnimatingSprite
    {
        //fields 
        private Player player;

        //constructor
        public PlayerLeft(Player player):base(player)
        {
            this.player = player;
            this.rotation = (float)Math.PI;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.player.Position -= new Vector2(this.player.Speed, 0f);
            if (Playermanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.player.Position.X / 32;
                this.player.Position = new Vector2((Geheel +1) * 32, this.player.Position.Y);
                if (Input.DetectKeyUp(Keys.A))
                {
                    this.player.State = new PlayerIdle(this.player, (float)Math.PI);
                }
            }

            if (Input.DetectKeyUp(Keys.A))
            {
                float modulo = this.player.Position.X % 32;

                if (modulo >= (32f - this.player.Speed))
                {
                    int Geheel = (int)this.player.Position.X / 32;
                    this.player.Position = new Vector2((Geheel + 1) * 32, this.player.Position.Y);
                    this.player.State = new PlayerIdle(this.player, (float)Math.PI);
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
