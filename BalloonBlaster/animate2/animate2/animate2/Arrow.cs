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
    class Arrow
    {
        public Texture2D texture;
        public Rectangle rect;
        public Vector2 position;
        public float speed;
        public bool n = false;

        //KeyboardState ks;

        public Arrow(Texture2D texture, Rectangle rectangle, Vector2 position, float speed)
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

        public void Update()
        {

            rect = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);

            if (n)
            {
                if(position.Y > -10)
                position.Y -= speed;

                if(position.Y <= -10)
                {
                    n = false;
                    position = new Vector2(5000, 5000);

                }
            }

        }

        

       
        public Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}
