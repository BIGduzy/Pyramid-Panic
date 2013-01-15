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
    public class Score
    {
        //fields
        private static int points, lives, scarab;
        private static bool doorsAreClosed;

        //properties
        public static bool DoorsAreClosed
        {
            get { return doorsAreClosed; }
            set { doorsAreClosed = value; }
        }

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public static int Scarab
        {
            get { return scarab; }
            set { scarab = value; }
        }


        public static void Initialize()
        {
            points = 0;
            lives = 3;
            scarab = 0;
            doorsAreClosed = true;
        }
       
        public static bool openDoor()
        {
            return (points >500) ? true : false;
        }

        public static bool isDead()
        {
            return (lives <1) ?true :false;
        }
    }
}
