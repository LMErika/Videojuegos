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
    public class Desplazamiento
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private int imageWidth;
        private int imageHeigth;
        private int windowWidth;
        private int windowHeigth;
        private int velocidad;
        private int sentido; // 0: Derecha - Izquierda, 1: Izquierda - Derecha, 2: Arriba - Abajo, 3: Abajo - Arriba
        private Rectangle rec1;
        private Rectangle rec2;
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
    this.x1 = x;
    this.y1 = y;

    if (sentido == 0)
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        x2 = x1 + windowWidth;
        rec2 = new Rectangle(x2, y1, imageHeigth, imageHeigth);
    }
    else if (sentido == 1)
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        x2 = x1 - windowWidth;
        rec2 = new Rectangle(x2, y1, imageHeigth, imageHeigth);
    }

    else if (sentido == 2)
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        y2 = y1 + windowHeigth;
        rec2 = new Rectangle(x1, y2, imageHeigth, imageHeigth);
    }
    else
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        y2 = y1 - windowHeigth;
        rec2 = new Rectangle(x1, y2, imageHeigth, imageHeigth);
    }
}

        public void Update()
{
    if (sentido == 0)
    {
        x1 -= velocidad;
        x2 -= velocidad;
    }
    else if (sentido == 1)
    {
        x1 += velocidad;
        x2 += velocidad;
    }

            else if (sentido == 2)
    {
        y1 -= velocidad;
        y2 -= velocidad;
    }
    else
    {
        y1 += velocidad;
        y2 += velocidad;
    }

    if (sentido == 0 || sentido == 1)
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        rec2 = new Rectangle(x2, y1, imageWidth, imageHeigth);
    }
    else
    {
        rec1 = new Rectangle(x1, y1, imageWidth, imageHeigth);
        rec2 = new Rectangle(x1, y2, imageWidth, imageHeigth);
    }



    if (sentido == 0)
    {
        if (rec1.X == -windowWidth)
        {
            x1 = 0;
        }

        if (rec2.X == 0)
        {
            x2 = windowWidth;
        }
    }
    else if (sentido == 1)
    {
        if (rec1.X == windowWidth)
        {
            x1 = 0;
        }

        if (rec2.X == 0)
        {
            x2 = -windowWidth;
        }
    }

    else if (sentido == 2)
    {
        if (rec1.Y == -windowHeigth)
        {
            y1 = 0;
        }

        if (rec2.Y == 0)
        {
            y2 = windowHeigth;
        }
    }
    else
    {
        if (rec1.Y == windowHeigth)
        {
            y1 = 0;
        }

        if (rec2.Y == 0)
        {
            y2 = -windowHeigth;
        }
    }
}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rec1, Color.White);
            spriteBatch.Draw(textura, rec2, Color.White);
        }




    }
}
