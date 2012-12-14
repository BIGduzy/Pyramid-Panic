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
            this.rotation = 0f;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.player.Position += new Vector2(this.player.Speed, 0f);
            if (Playermanager.CollisionDetectionWalls())
            {
                int Geheel = (int)this.player.Position.X / 32;
                this.player.Position = new Vector2(Geheel  * 32, this.player.Position.Y);
                if (Input.DetectKeyUp(Keys.D))
                {
                 this.player.State = new PlayerIdle(this.player, 0f);
                }
            }

            if (Input.DetectKeyUp(Keys.D))
            {
              float modulo = this.player.Position.X % 32;

              if (modulo >= (32f - this.player.Speed))
              {
                int Geheel = (int)this.player.Position.X / 32;
                this.player.Position = new Vector2((Geheel + 1) * 32, this.player.Position.Y);
                this.player.State = new PlayerIdle(this.player, 0f);
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
