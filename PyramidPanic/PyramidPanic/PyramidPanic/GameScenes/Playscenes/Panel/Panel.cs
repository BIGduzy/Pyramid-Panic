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
    public class Panel
    {
        //fields
        private PyramidPanic game;
        private Vector2 position;
        private SpriteFont font;
        private List<Picture> pictures;


        //constructor
        public Panel(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.Initialize();

        }


        private void Initialize()
        {
            this.font = this.game.Content.Load<SpriteFont>(@"PlayScene\Fonts\Pfont");
            this.pictures = new List<Picture>();
            this.LoadContent();
        }

        private void LoadContent()
        {
            this.pictures.Add(new Picture(this.game, @"PlayScene\Panel\Panel", this.position));
            this.pictures.Add(new Picture(this.game, @"PlayScene\Panel\Lives", this.position+new Vector2 (2.5f*32f,0f)));
            this.pictures.Add(new Picture(this.game, @"PlayScene\Tressures\Scarab", this.position + new Vector2(7.5f * 32f, 0f)));
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Picture picture in this.pictures)
            {
                picture.Draw(gameTime);
            }

            this.game.SpriteBatch.DrawString(this.font, Score.Lives.ToString(),this.position + new Vector2(3.6f*32f,-2f),Color.Goldenrod);
            this.game.SpriteBatch.DrawString(this.font, Score.Scarab.ToString(), this.position + new Vector2(8.6f * 32f, -2f), Color.Goldenrod);
            this.game.SpriteBatch.DrawString(this.font, Score.Points.ToString(), this.position + new Vector2(16.6f * 32f, -2f), Color.Goldenrod);
        }



    }
}
