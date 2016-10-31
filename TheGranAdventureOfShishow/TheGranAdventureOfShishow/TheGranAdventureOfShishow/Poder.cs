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

namespace TheGranAdventureOfShishow
{
    class Poder
    {
        private Texture2D textureLeft;
        private Texture2D textureRight;
        private Rectangle rectangle;
        private Direccion direccion;
        private int x;
        private int y;
        private int speed;

        public void Initialaze(Texture2D textureLeft,
        Texture2D textureRight,
        Direccion direccion,
        int x,    int y)
        {
            this.textureLeft = textureLeft;
            this.textureRight = textureRight;
            this.direccion = direccion;
            this.x = x;
            this.y = y;
            this.rectangle = new Rectangle(x, y, 50, 20);
            this.speed = 5; 

        }

        public void Update(GameTime gameTime)
        {
            if (direccion == Direccion.LeftRight)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }
            rectangle.X = x;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direccion == Direccion.LeftRight)
            {
                spriteBatch.Draw(textureRight,rectangle,Color.White);
            }
            else
            {
                spriteBatch.Draw(textureLeft, rectangle, Color.White);
            }
        }







    }

}
