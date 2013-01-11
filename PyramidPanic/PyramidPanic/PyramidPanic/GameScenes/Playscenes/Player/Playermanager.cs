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
    public class Playermanager
    {
        //fields
        private static Level level;
        private static Player player;

        //properties
        public static Level Level
        {
            set
            {
                level = value;
            }
        }

        public static Player Player
        {
            set { player = value; }
        }

        //constructor
        public static bool CollisionDetectionWalls()
        {
            for (int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < level.Blocks.GetLength(1);j++ )
                {
                    if (level.Blocks[i, j].BlockColision == BlockColision.Npas)
                    {
                        if (player.CollisionRec.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        public static void CollisionDetectTreasures()
        {
            foreach (Treasure treasure in level.Treasures)
            {
                if (player.CollisionRec.Intersects(treasure.Rectangle))
                {
                    switch (treasure.Character)
                    {

                        case 'a':
                            Score.Points += 10;
                            break;
                        case 'b':
                            Score.Points += 100;
                            break;
                        case 'c':
                            Score.Lives += 1;
                            break;
                        case 'd':
                            Score.Points += 50;
                            Score.Scarab += 1;
                            break;
                    }
                    level.Treasures.Remove(treasure);
                    break;
                }
                
            }

        }

        public static void CollisionDetectScorpions()
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                if (player.CollisionRec.Intersects(scorpion.Collisionrec))
                {
                    Score.Lives -= 1;
                    level.LevelPause.RemoveIdex = level.Scorpions.IndexOf(scorpion);
                    level.LevelPause.RemoveType = "scorpion";
                    level.LevelState = new LevelPause(level);
                    
                    break;
                }
            }
        }

        public static void CollisionDetectBeetles()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                if (player.CollisionRec.Intersects(beetle.Collisionrec))
                {
                    Score.Lives -= 1;
                    level.LevelPause.RemoveIdex = level.Beetles.IndexOf(beetle);
                    level.LevelPause.RemoveType = "beetle";
                    level.LevelState = new LevelPause(level);
                    
                    break;
                }
            }
        }
    }
}
