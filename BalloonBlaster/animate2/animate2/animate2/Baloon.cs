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
    class Baloon
    {
        public Texture2D texture;
        public Rectangle rect;
        public Vector2 position;
        public float speed;
        public bool doUpdate = true;


        Vector2 spriteSpeed = new Vector2(175f, 175f);

        public Baloon(Texture2D texture, Rectangle rectangle, Vector2 position, float speed)
        {
            this.texture = texture;
            this.rect = rectangle;
            this.position = position;
            this.speed = speed;
        }


        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(texture, this.position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

        public void Update(GameTime gameTime)
        {
            if (doUpdate)
            {
                rect = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);

                position += spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //int MaxX =graphics.GraphicsDevice.Viewport.Width - im.Width;

                int MaxX = (1280 - (-200)) -5;
                int MinX = -200;

               // int MaxX = (0 - 200) - 5; 
               // int MaxY = graphics.GraphicsDevice.Viewport.Height - im.Height;

                int MaxY = (720 / 3) - 5;
                int MinY = -150;

                // Check for bounce.
                if (position.X > MaxX)
                {
                    spriteSpeed.X *= -1;
                    position.X = MaxX;
                }

                else if (position.X < MinX)
                {
                    spriteSpeed.X *= -1;
                    position.X = MinX;
                }

                if (position.Y > MaxY)
                {
                    spriteSpeed.Y *= -1;
                    position.Y = MaxY;
                }

                else if (position.Y < MinY)
                {
                    spriteSpeed.Y *= -1;
                    position.Y = MinY;
                }

            }
            else
            {
                position = new Vector2(10000, 10000);
            }
        }

        public Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}
