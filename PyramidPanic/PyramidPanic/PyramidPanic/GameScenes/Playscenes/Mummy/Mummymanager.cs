﻿using System;
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
    public class Mummymanager
    {
        //fields
        private static Level level;
        private static Mummy mummy;

        //properties
        public static Level Level
        {
            set
            {
                level = value;
            }
        }

        public static Mummy Mummy
        {
            set { mummy = value; }
        }

       

        //constructor
        public static bool CollisionDetectionWalls()
        {
            for (int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < level.Blocks.GetLength(1); j++)
                {
                    if (level.Blocks[i, j].BlockColision == BlockColision.Npas)
                    {
                        if (mummy.CollisionRec.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        
    }
}
