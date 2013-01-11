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
    
   public class Level
    {
       //fields
       private PyramidPanic game;
       private string levelPath;
       private List<string> lines;
       private Block[,] blocks;
       //private Scorpion scorpion;
       //private Beetle beetle;
       private const int GRIDWIDTH = 32;
       private const int GRIDHEIGHT = 32;
       private Picture background;
       private List<Picture> treasures;
       private List<Scorpion> scorpions;
       private List<Beetle> beetles;
       private Panel panel;
       private Player player;
       private ILevel levelState;
       private LevelPause levelPause;
       private LevelPlay levelPlay;

       //properties
       public PyramidPanic Game
       {
           get {return this.game ;}
       }

       public Player Player
       {
           get { return this.player;}
       }

       public List<Picture> Treasures
       {
           get { return this.treasures; }
           set { this.treasures = value; }
       }

       public List<Beetle> Beetles
       {
           get {return this.beetles ;}
       }
       public List<Scorpion> Scorpions
       {
           get { return this.scorpions; }
       }
       public Block[,] Blocks
       {
           get { return this.blocks; }
       }

       public LevelPause LevelPause
       {
           get{return this.levelPause;}
           set{ this.levelPause = value;}
       }

       public ILevel LevelState
       {
           get { return this.levelState; }
           set { this.levelState = value; }
       }

       public LevelPlay LevelPlay
       {
           get { return this.levelPlay; }
           set { this.levelPlay = value; }
       }



       //constructor
       public Level(PyramidPanic game, int levelIndex)
       {
           this.game = game;
           this.levelPath = @"Content\PlayScene\Levels\0.txt";
           this.LoadAssets();
           Score.Initialize();
           this.levelPause = new LevelPause(this);
           this.levelPlay = new LevelPlay(this);
           this.levelState = this.levelPlay;

       }

       private void LoadAssets()
       {
           this.treasures = new List<Picture>();
           this.scorpions = new List<Scorpion>();
           this.beetles = new List<Beetle>();
           this.panel = new Panel(this.game, new Vector2(0f, 448f));
           this.lines = new List<string>();
           StreamReader reader = new StreamReader(this.levelPath);
           string line = reader.ReadLine();
          
           int width = line.Length;
           //Console.WriteLine(width);
           while (line != null)
           {
               lines.Add(line);
               line = reader.ReadLine();
              
           }
           int height = lines.Count;
           this.blocks = new Block[width, height];
           //Console.WriteLine(height);
           reader.Close();

           for (int row = 0; row < height; row++)
           {
               for (int column = 0; column < width; column++)
               {

                   char blockElement = this.lines[row][column];
                   this.blocks[column,row] = LoadBlock(blockElement,column*GRIDWIDTH, row*GRIDHEIGHT);
               }

           }
           BeetleManager.Level = this;
           ScorpionManager.Level = this;
           Playermanager.Level = this;
           
       }

       private Block LoadBlock(char blockElement,int x,int y)
       {
           switch (blockElement)
           {
               case 'a':
                   this.treasures.Add(new Treasure('a',this.game, @"PlayScene\Tressures\Treasure1",new Vector2(x,y)));
                   return new Block(this.game, @"Transparant", new Vector2(x,y), BlockColision.Pas, 'a');
                   

               case 'b':
                   this.treasures.Add(new Treasure('b',this.game, @"PlayScene\Tressures\Treasure2", new Vector2(x, y)));
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 'b');

               case 'c':
                   this.treasures.Add(new Treasure('c',this.game, @"PlayScene\Tressures\Potion", new Vector2(x, y)));
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 'c');

               case 'd':
                   this.treasures.Add(new Treasure('d',this.game, @"PlayScene\Tressures\Scarab", new Vector2(x, y)));
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 'd');

               case 'r':
                   this.beetles.Add(new Beetle(this.game, new Vector2(x, y), 4));
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 'r');

               case 's':
                   this.scorpions.Add( new Scorpion(this.game, new Vector2(x,y),4));
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 's');

               case 'w':
                   return new Block(this.game, @"Block", new Vector2(x,y),BlockColision.Npas,'w');

               case 'y':
                   return new Block(this.game, @"Door", new Vector2(x, y), BlockColision.Pas, 'y');

               case 'x':
                   return new Block(this.game, @"Wall1", new Vector2(x, y), BlockColision.Npas, 'x');

               case 'z':
                   return new Block(this.game, @"Wall2", new Vector2(x, y), BlockColision.Npas, 'y');

               case 'P':
                   this.player = new Player(this.game,new Vector2(x,y),3.0f);
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, 'P');
                   
               case '.':
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, '.');

                case '@':
                   this.background = new Picture(this.game, @"PlayScene\Background\Background2",new Vector2(x,y));
                   return new Block(this.game, @"Wall1", new Vector2(x, y), BlockColision.Npas, '@');
                   
               default:
                   return new Block(this.game, @"Transparant", new Vector2(x, y), BlockColision.Pas, '.');
                   
           }
       }

       public void Update(GameTime gameTime)
       {
           this.levelState.Update(gameTime);
       }

       public void Draw(GameTime gameTime)
       {
           this.background.Draw(gameTime);
           

           for (int row = 0; row < this.blocks.GetLength(1); row++)
           {
               for (int column = 0; column < this.blocks.GetLength(0); column++)
               {
                   this.blocks[column, row].Draw(gameTime);
               }
           }

           foreach (Picture tressures in this.treasures)
           {
               tressures.Draw(gameTime);
           }


           foreach (Scorpion scorpions in this.scorpions)
           {
               scorpions.Draw(gameTime);
           }

           foreach (Beetle beetles in this.beetles)
           {
               beetles.Draw(gameTime);
           }

           if (this.player != null)
           { this.player.Draw(gameTime); }

           this.levelState.Draw(gameTime);

           this.panel.Draw(gameTime);
       }

    }
}
