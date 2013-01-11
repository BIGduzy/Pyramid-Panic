using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class LevelPlay : ILevel
    {
        //fields
        private Level level;

        //constructor
        public LevelPlay(Level level) 
        {
            this.level = level;
        }

        //Update
        public void Update(GameTime gameTime)
        {

            foreach (Scorpion scorpions in level.Scorpions)
            {

                scorpions.Update(gameTime);
            }

            foreach (Beetle beetles in level.Beetles)
            {

                beetles.Update(gameTime);
            }
            level.Player.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {

        }
    }
}
