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
    public static class Input
    {
        //fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static Rectangle mouseRec;

        //constructor
        static Input()
        {
            mouseRec = new Rectangle(0,0,1,1);

            ks = Keyboard.GetState();
            oks = Keyboard.GetState();
        }

        //update
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }

        //LevelDetecter voor de toetsenknoppen
        public static bool DetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

        //levelDetecter voor loslaten
        public static bool DetectKeyUp(Keys key)
        {
            return ks.IsKeyUp(key);
        }

        //edgedecet voor de toetsenknoppen
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //edgedecector voor de muis(linker knop)
        public static bool MouseEdgeDetectPressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released );
        }

        //edgedecector voor de muis(rechter knop)
        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }

        //positie van de muis.
        public static Vector2 MousePosition()
        {
            return new Vector2(ms.Y, ms.X);
        }

        //
        public static Rectangle MouseRec()
        {
            mouseRec.X = ms.X;
            mouseRec.Y=ms.Y;
            return mouseRec;
        }
    }
}
