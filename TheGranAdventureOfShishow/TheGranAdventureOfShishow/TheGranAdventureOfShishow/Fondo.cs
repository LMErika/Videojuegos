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
    public class Fondo
    {

        public Texture2D imagen; public Rectangle cuadro;
        public Fondo(Texture2D imagen, Rectangle cuadro)
        {
            this.imagen = imagen; this.cuadro = cuadro;
        }
        public void Update()
        {
            cuadro.X -= 2;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(imagen, cuadro, Color.White);
        }
    }
}
