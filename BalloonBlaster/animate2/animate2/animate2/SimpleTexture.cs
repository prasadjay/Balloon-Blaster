using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace animate2
{
    class SimpleTexture
    {

        public Texture2D texture;
        public Rectangle rect;
        public Vector2 position;

        public SimpleTexture(Texture2D texture, Rectangle rectangle, Vector2 position)
        {
            this.texture = texture;
            this.rect = rectangle;
            this.position = position;

        }


        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(texture, this.position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

        }

        public void DrawBackground(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(texture, this.position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

        }

        public void Update()
        {

            rect = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }

        public void UpdateCrosshair()
        {
            rect = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position.X -= 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position.X += 6;

        }

        public Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }


    }
}
