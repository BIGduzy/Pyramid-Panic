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
    public class BeetleManager
    {
        //field
        private static Level level;

        //properties
        public static Level Level
        {
            set 
            {
                level = value;
                CollisionWallBeetleUp();
                CollisionWallBeetleDown();
            }
        }

        private static void CollisionWallBeetleUp()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int i = ((int)beetle.Position.Y / 32); i >= 0; i--)
                {
                    if (level.Blocks[(int)beetle.Position.X/32,i].BlockColision == BlockColision.Npas)
                    {
                        beetle.Top = (i+1) * 32;
                        break;
                    }
                }
            }
        }


        private static void CollisionWallBeetleDown()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int i = ((int)beetle.Position.Y / 32); i <=13; i++)
                {
                    if (level.Blocks[(int)beetle.Position.X / 32, i].BlockColision == BlockColision.Npas)
                    {
                        beetle.Bot = (i-1) * 32;
                        break;
                    }
                }
            }
        }


    }
}
