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
    class Health
    {
        public Texture2D texture;
        public Rectangle rect;
        public Vector2 position;
        public float speed;
        public bool doUpdate = true;
        public bool n = false;


        Vector2 spriteSpeed = new Vector2(0f, 70f);

        public Health(Texture2D texture, Rectangle rectangle, Vector2 position, float speed)
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


            if (n)
            {
                //if (position.Y < -50)
                position.Y += speed;

                if (position.Y > 710)
                {
                    n = false;
                    position = new Vector2(50000, 50000);

                }
            }


            //if (doUpdate)
            //{
            //    rect = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);

            //    position += spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //    position.Y += 1; 

            //}
            //else
            //{
            //    position = new Vector2(10000, 10000);
            //}
        }

        public Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}

