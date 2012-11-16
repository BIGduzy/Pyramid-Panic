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
    public class MenuStartScene
    {

        private enum Buttonstate { Start, Load, Leveledit, Score, Help, quit }

        //fields
        private Picture start, load, help, score, quit, leveledit;
        private PyramidPanic game;
        private int top, left, space;
        private Buttonstate buttonstate;
        private Color buttoncolor = Color.DarkGoldenrod;
        
        

        //constructor
        public MenuStartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.buttonstate = Buttonstate.Start;
            this.top = 430;
            this.left = 3;
            this.space = 107;
            this.Loadcontent();

        }

        //update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.buttonstate++;
                if (this.buttonstate > Buttonstate.quit)
                {
                    this.buttonstate = Buttonstate.Start;
                }
                
            }

            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.buttonstate--;
                if (this.buttonstate < Buttonstate.Start)
                {
                    this.buttonstate = Buttonstate.quit;
                }
                
            }

            //keyboard buttons 
            if (Input.EdgeDetectKeyDown(Keys.Enter))
            {
                if (this.buttonstate == Buttonstate.Start)
                {
                    this.game.GameState = new PlayScene(this.game);
                }  

                if (this.buttonstate == Buttonstate.Load)
                {
                    this.game.GameState = new LoadScene(this.game);
                }

                if (this.buttonstate == Buttonstate.Leveledit)
                {
                    this.game.GameState = new LevelEditorScene(this.game);
                }

                if (this.buttonstate == Buttonstate.Score)
                {
                    this.game.GameState = new ScoreScene(this.game);
                }

                if (this.buttonstate == Buttonstate.Help)
                {
                    this.game.GameState = new HelpScene(this.game);
                }

                if (this.buttonstate == Buttonstate.quit)
                {
                    this.game.GameState = new QuitScene(this.game);
                }
            }

            //mouse buttons
            if (Input.MouseEdgeDetectPressLeft())
            {
                if (this.start.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new PlayScene(this.game);
                }

                if (this.load.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new LoadScene(this.game);
                }

                if (this.leveledit.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new LevelEditorScene(this.game);
                }

                if (this.score.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new ScoreScene(this.game);
                }

                if (this.help.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new HelpScene(this.game);
                }

                if (this.quit.Rectangle.Intersects(Input.MouseRec()))
                {
                    this.game.GameState = new QuitScene(this.game);
                }

            }
            
        }
        //loadContent
        private void Loadcontent()
        {
            this.start = new Picture(this.game,"Buttons\\Button_start",new Vector2(this.left,this.top));
            this.load = new Picture(this.game,"Buttons\\Button_load",new Vector2(this.left+this.space,this.top));
            this.leveledit = new Picture(this.game, "Buttons\\Button_leveleditor", new Vector2(this.left+this.space*2, this.top));
            this.score = new Picture(this.game, "Buttons\\Button_scores", new Vector2(this.left+this.space*3, this.top));
            this.help = new Picture(this.game, "Buttons\\Button_help", new Vector2(this.left+this.space*4, this.top));
            this.quit = new Picture(this.game, "Buttons\\Button_quit", new Vector2(this.left+this.space*5, this.top));
            
            
        }



        //draw
        public void Draw(GameTime gameTime)
        {
            Color buttoncolorstart = Color.White;
            Color buttoncolorload = Color.White;
            Color buttoncolorleveledit = Color.White;
            Color buttoncolorscore = Color.White;
            Color buttoncolorhelp = Color.White;
            Color buttoncolorquit = Color.White;

            switch(this.buttonstate)
            {
                case Buttonstate.Start:
                    buttoncolorstart = this.buttoncolor;
                    break;

                case Buttonstate.Load:
                    buttoncolorload = this.buttoncolor;
                    break;

                case Buttonstate.Help:
                    buttoncolorhelp = this.buttoncolor;
                    break;

                case Buttonstate.Leveledit:
                    buttoncolorleveledit = this.buttoncolor;
                    break;

                case Buttonstate.Score:
                    buttoncolorscore = this.buttoncolor;
                    break;

                case Buttonstate.quit:
                    buttoncolorquit = this.buttoncolor;

                    break;
                default:
                    break;
            }

            this.start.Draw(this.game.SpriteBatch, buttoncolorstart);
            this.load.Draw(this.game.SpriteBatch, buttoncolorload);
            this.leveledit.Draw(this.game.SpriteBatch, buttoncolorleveledit);
            this.score.Draw(this.game.SpriteBatch, buttoncolorscore);
            this.help.Draw(this.game.SpriteBatch, buttoncolorhelp);
            this.quit.Draw(this.game.SpriteBatch, buttoncolorquit);
        }
    }
}
