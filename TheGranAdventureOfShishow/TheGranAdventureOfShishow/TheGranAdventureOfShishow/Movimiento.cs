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
   public  class Movimiento

       
    {


        private int x; //rectangulo
        private int y; //rectangulo
        private int imageWidth;
        private int imageHeigth;
        private int windowWidth;
        private int windowHeigth;
        private int velocidad;
        private int sentido; // 0: Derecha - Izquierda, 1: Izquierda - Derecha, 2: Arriba - Abajo, 3: Abajo - Arriba
        private Rectangle rectangulo;
        private Texture2D textura;


        public void Initialize(Texture2D textura, int x, int y, int imageWidth, int imageHeigth,
     int windowWidth, int windowHeigth, int velocidad, int sentido)
        {
            this.textura = textura;
            this.imageHeigth = imageHeigth;
            this.imageWidth = imageWidth;
            this.windowHeigth = windowHeigth;
            this.windowWidth = windowWidth;
            this.velocidad = velocidad;
            this.sentido = sentido;
            this.x = x;
            this.y = y;

            rectangulo = new Rectangle(x, y, imageWidth, imageHeigth);
        }


        public void Update()
        {
            if (sentido == 0)
            {
                x += velocidad;
                if (x == windowWidth) x = 0;
            }
            else if (sentido == 1)
            {
                x -= velocidad;
                if (x == -imageWidth) x = windowWidth - imageWidth;
            }
            else if (sentido == 2)
            {
                y += velocidad;
                if (y == windowHeigth) y = 0;
            }
            else
            {
                y -= velocidad;
                if (y == -imageHeigth) y = windowHeigth - imageHeigth;
            }

            rectangulo.X = x;
            rectangulo.Y = y;
        }
   
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rectangulo, Color.White);
        }


    }
}
