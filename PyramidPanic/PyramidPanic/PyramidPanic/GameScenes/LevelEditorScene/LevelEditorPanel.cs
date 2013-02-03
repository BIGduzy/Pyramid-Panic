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
             foreach(Picture picture in this.levelEditorAssets)
             {
                 if(picture.Rectangle.Intersects(Input.MouseRec()))
                 {
                     int indexOfPicture = this.levelEditorButtons.IndexOf(picture);


                     if (Input.MouseEdgeDetectPressLeft())
                     {
                         switch (indexOfPicture)
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
                                 Console.WriteLine(this.levelEditorAssetsIndex);
                                 break;
                             case 3:
                                 this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex < this.levelEditorAssets.Count - 1) ?
                                     this.levelEditorAssetsIndex + 1 : this.levelEditorAssets.Count - 1;
                                 Console.WriteLine(this.levelEditorAssetsIndex);
                                 break;
                             default:
                                 break;
                         }
                     }
                 }

             }
         }

         //Draw
         public void Draw(GameTime gameTime)
         {
             this.background.Draw(gameTime);
             foreach (Picture picture in this.levelEditorAssets)
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
