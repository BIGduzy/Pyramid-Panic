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
            if (Playermanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.player.Position.Y / 32;
                this.player.Position = new Vector2(this.player.Position.X, (Geheel+1) * 32);
                if (Input.DetectKeyUp(Keys.W))
                {
                    this.player.State = new PlayerIdle(this.player, this.rotation);
                }
            }

            if (Input.DetectKeyUp(Keys.W))
            {
                float modulo = (this.player.Position.Y >= 0) ? this.player.Position.Y % 32 : 32 + this.player.Position.Y;

                if (modulo >= (32f - this.player.Speed))
                {
                    int Geheel = (int)this.player.Position.Y / 32;
                    this.player.Position = (this.player.Position.Y >= 0) ? new Vector2(this.player.Position.X, (Geheel + 1) * 32) : new Vector2(this.player.Position.X, (Geheel) * 32);
                    this.player.State = new PlayerIdle(this.player,this.rotation);
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
