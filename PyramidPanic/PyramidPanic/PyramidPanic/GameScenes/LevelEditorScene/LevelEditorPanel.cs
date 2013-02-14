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

namespace PyramidPanic
{
     public class LevelEditorPanel
    {
         //field
         private LevelEditorScene levelEditorScene;
         private Vector2 position;
         private Picture background;
         private List<Picture> levelEditorButtons,levelEditorAssets;
         private SpriteFont Arial;
         private int levelEditorAssetsIndex = 0;

         //Properties
         public List<Picture> LevelEditorAssets
         {
             get {return this.levelEditorAssets;}
         }

         //Constructor
         public LevelEditorPanel(LevelEditorScene levelEditorScene,Vector2 position)
         {
             this.levelEditorScene = levelEditorScene;
             this.position = position;
             this.Initialize();
         }
         //Initialize
         private void Initialize()
         {
             this.LoadContent();
         }
         //loadContent
         private void LoadContent()
         {
             this.Arial = this.levelEditorScene.Game.Content.Load<SpriteFont>(@"PlayScene\Fonts\Arial");
             this.levelEditorButtons = new List<Picture>();
             this.levelEditorAssets = new List<Picture>();
             //levelnumber verlagen
             this.levelEditorButtons.Add(
                 new Picture(this.levelEditorScene.Game, @"LevelEdit\Left",
                     this.position + new Vector2(2.5f * 32f, 0f)));
             //levelnumber verhogen
             this.levelEditorButtons.Add(
                 new Picture(this.levelEditorScene.Game, @"LevelEdit\Right",
                     this.position + new Vector2(4.5f * 32f, 0f)));
             //save
             this.levelEditorButtons.Add(
                 new Picture(this.levelEditorScene.Game, @"LevelEdit\Button_load",
                     this.position + new Vector2(15f * 32f, 0f)));
             //plaatje wisselen naar beneden in list
             this.levelEditorButtons.Add(
                 new Picture(this.levelEditorScene.Game, @"LevelEdit\Left",
                     this.position + new Vector2(9f * 32f, 0f)));
             //plaatje wisselen naar omhoog in list
             this.levelEditorButtons.Add(
                 new Picture(this.levelEditorScene.Game, @"LevelEdit\Right",
                     this.position + new Vector2(11f * 32f, 0f)));

             //Assets toevoegen aan de list levelEditorAssets
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"PlayScene\Blocks\Block",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"PlayScene\Blocks\Door",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"PlayScene\Blocks\Wall1",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"PlayScene\Blocks\Wall2",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Beetle",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Scorpion",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\mummy",
                                                     this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Potion",
                                                    this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Scarab",
                                                    this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Treasure1",
                                                    this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"LevelEdit\Treasure2",
                                                    this.position + new Vector2(10f * 32f, 0f)));
             this.levelEditorAssets.Add(new Picture(this.levelEditorScene.Game, @"PlayScene\Panel\Lives",
                                                    this.position + new Vector2(10f * 32f, 0f)));
             this.background = new Picture(this.levelEditorScene.Game, @"LevelEdit\Panel", this.position);
         }

         //Update
         public void Update(GameTime gameTime)
         {
             foreach (Picture picture in this.levelEditorButtons)
             {
                 if (picture.Rectangle.Intersects(Input.MouseRec()))
                 {
                     //Bepaal om welk image het gaat in list en geef het indexnummer
                     int indexOfImage = this.levelEditorButtons.IndexOf(picture);

                     //Detecteer of er linksgeklikt wordt op muisknop
                     if (Input.MouseEdgeDetectPressLeft())
                     {
                         switch (indexOfImage)
                         {
                             case 0:
                                 this.levelEditorScene.LevelNumber = (this.levelEditorScene.LevelNumber > 0) ?
                                     this.levelEditorScene.LevelNumber - 1 : 0;
                                 this.levelEditorScene.loadLevel();
                                 break;

                             case 1:
                                 this.levelEditorScene.LevelNumber = (this.levelEditorScene.LevelNumber < 10) ?
                                     this.levelEditorScene.LevelNumber + 1 : 10;
                                 this.levelEditorScene.loadLevel();
                                 break;

                             case 2:
                                 this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex > 0) ?
                                     this.levelEditorAssetsIndex - 1 : 0;
                                 //Console.WriteLine(this.levelEditorAssetsIndex);
                                 break;

                             case 3:
                                 this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex < this.levelEditorAssets.Count - 1) ?
                                     this.levelEditorAssetsIndex + 1 : this.levelEditorAssets.Count - 1;
                                 //Console.WriteLine(this.levelEditorAssetsIndex);
                                 break;

                             case 4:
                                 this.SaveGame();
                                 break;

                             default:
                                 break;
                         }
                     }
                 }
             }

             if ((Input.MouseEdgeDetectPressLeft() || Input.MouseEdgeDetectPressRight()) &&
                Input.MousePosition().X < 640f &&
                Input.MousePosition().X > 0f &&
                Input.MousePosition().Y > 0f &&
                Input.MousePosition().Y < 448f)
             {
                 if (Input.MouseEdgeDetectPressRight())
                 {
                     this.RemoveAsset();
                 }
                 else
                 {
                     if (this.levelEditorScene.Level.Player.Position !=
                        new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                    ((int)Input.MousePosition().Y / 32) * 32))
                     {
                         this.RemoveAsset();
                         switch (this.levelEditorAssetsIndex)
                         {
                             case 0:
                                 this.PlaceBlock(@"Block", 'w');
                                 break;
                             case 1:
                                 this.PlaceBlock(@"Door", 'z');
                                 break;
                             case 2:
                                 this.PlaceBlock(@"Wall1", 'x');
                                 break;
                             case 3:
                                 this.PlaceBlock(@"Wall2", 'y');
                                 break;
                             case 4:
                                 this.PlaceBlock(@"Transparant", 'b');
                                 this.levelEditorScene.Level.Beetles.Add(new Beetle(this.levelEditorScene.Game,
                                                                         new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                     ((int)Input.MousePosition().Y / 32) * 32f),
                                                                         2.0f));
                                 break;
                             case 5:
                                 this.PlaceBlock(@"Transparant", 's');
                                 this.levelEditorScene.Level.Scorpions.Add(new Scorpion(this.levelEditorScene.Game,
                                                                           new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                     ((int)Input.MousePosition().Y / 32) * 32f),
                                                                           2.0f));
                                 break;
                             case 6:
                                 this.PlaceBlock(@"Transparant", 'M');
                                 this.levelEditorScene.Level.Mummys.Add(new Mummy(this.levelEditorScene.Game,
                                                                        new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                    ((int)Input.MousePosition().Y / 32) * 32f),
                                                                           2.0f));
                                 break;
                             case 7:
                                 this.PlaceBlock(@"Transparant", 'c');
                                 this.addTreasure('c', @"PlayScene\Treasures\Potion");
                                 break;
                             case 8:
                                 this.PlaceBlock(@"Transparant", 'd');
                                 this.addTreasure('d', @"PlayScene\Treasures\Scarab");
                                 break;
                             case 9:
                                 this.PlaceBlock(@"Transparant", 'a');
                                 this.addTreasure('a', @"PlayScene\Treasures\Treasure1");
                                 break;
                             case 10:
                                 this.PlaceBlock(@"Transparant", 'b');
                                 this.addTreasure('b', @"PlayScene\Treasures\Treasure2");
                                 break;
                             case 11:
                                 this.PlaceBlock(@"Transparant", 'P');
                                 this.levelEditorScene.Level.Player = new Player(this.levelEditorScene.Game,
                                                                                     new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                                 ((int)Input.MousePosition().Y / 32) * 32f),
                                                                                     2.0f);
                                 break;

                         }
                     }
                 }
             }
         }

         //PlaceBlock
         private void PlaceBlock(string name, Char charItem)
         {
             this.levelEditorScene.Level.Blocks[(int)Input.MousePosition().X / 32, (int)Input.MousePosition().Y / 32] = new Block(this.levelEditorScene.Game, name, new Vector2(((int)Input.MousePosition().X / 32) * 32f, ((int)Input.MousePosition().Y / 32) * 32f), BlockColision.Npas, charItem);
         }

         //addTreasure
         private void addTreasure(Char charItem, string name)
         {
             this.levelEditorScene.Level.Treasures.Add(new Treasure(charItem,
                                                                    this.levelEditorScene.Game,
                                                                    name,
                                                                    new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                               ((int)Input.MousePosition().Y / 32) * 32f)));
         }

         //RemoveAsset
         private void RemoveAsset()
         {
             foreach (Scorpion scorpion in this.levelEditorScene.Level.Scorpions)
             {
                 if (scorpion.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                 {
                     this.levelEditorScene.Level.Scorpions.Remove(scorpion);
                     break;
                 }
             }

             foreach (Treasure treasure in this.levelEditorScene.Level.Treasures)
             {
                 if (treasure.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                 {
                     this.levelEditorScene.Level.Treasures.Remove(treasure);
                     break;
                 }
             }

             foreach (Beetle beetle in this.levelEditorScene.Level.Beetles)
             {
                 if (beetle.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                 {
                     this.levelEditorScene.Level.Beetles.Remove(beetle);
                     break;
                 }
             }

             foreach (Mummy mummy in this.levelEditorScene.Level.Mummys)
             {
                 if (mummy.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                 {
                     this.levelEditorScene.Level.Mummys.Remove(mummy);
                     break;
                 }
             }

             for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
             {
                 for (int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
                 {
                     if (this.levelEditorScene.Level.Blocks[i, j].Position ==
                         new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                     ((int)Input.MousePosition().Y / 32) * 32))
                     {
                         this.PlaceBlock("Transparant", '.');
                     }
                 }
             }
         }

         //SaveGame
         private void SaveGame()
         {
             string contentLevelPath = @"C:\Users\Nick\Documents\Visual Studio 2010\Projects\block 2\PyramidPanic\PyramidPanic\PyramidPanicContent\PlayScene\Levels\" + this.levelEditorScene.Level.Levelindex + ".txt";
             //Tekstbestand in de executable
             StreamWriter writer =
                 new StreamWriter(new FileStream(this.levelEditorScene.Level.LevelPath,
                                                 FileMode.Open,
                                                 FileAccess.Write));
             //Tekstbestand in het project
             StreamWriter writer1 =
                 new StreamWriter(new FileStream(contentLevelPath,
                                                 FileMode.Open,
                                                 FileAccess.Write));
             string line = "";
             for (int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
             {
                 for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
                 {
                     line += this.levelEditorScene.Level.Blocks[i, j].CharItem;
                 }
                 writer.WriteLine(line);
                 writer1.WriteLine(line);
                 line = "";
             }
             writer.Close();
             writer1.Close();
         }

         //Draw
         public void Draw(GameTime gameTime)
         {
             this.background.Draw(gameTime);
             foreach (Picture picture in this.levelEditorButtons)
             {
                 picture.Draw(gameTime);
             }
             this.levelEditorAssets[this.levelEditorAssetsIndex].Draw(gameTime);
             float levelIndexOffset = (levelEditorScene.LevelNumber > 9) ? 3.4f : 3.7f;
             this.levelEditorScene.Game.SpriteBatch.DrawString(this.Arial,
                 this.levelEditorScene.LevelNumber.ToString(), this.position +
                 new Vector2(levelIndexOffset * 32f, -3f), Color.Yellow);
         }
             
    }
}
