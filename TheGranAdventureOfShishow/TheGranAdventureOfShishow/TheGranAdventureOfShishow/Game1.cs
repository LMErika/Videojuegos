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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Jugador jugador;
        SpriteFont miFuente;
        int width;
        int height;
        KeyboardState previoKeyboard;


        #region Fondo
        //Fondo__________________________________________________________________________________
        Fondo fondo1, fondo2, fondo3, fondo4; Rectangle rFondo1, rFondo2, rFondo3, rFondo4;
        //_______________________________________________________________________________________
        #endregion Fondo


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            height=480;
            width = 800;
             graphics.PreferredBackBufferHeight=height;
             graphics.PreferredBackBufferWidth=width;
        }

 
        protected override void Initialize()
        {

           jugador = new Jugador();
            

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Fondo
            //Fondo_______________________________________________________________________________________________________________________
            rFondo1 = new Rectangle(0, 0, 800, 480); fondo1 = new Fondo(this.Content.Load<Texture2D>("Fondo/MontanaNoche1"), rFondo1);
            rFondo2 = new Rectangle(800, 0, 800, 480); fondo2 = new Fondo(this.Content.Load<Texture2D>("Fondo/MontanaNoche2"), rFondo2);
            rFondo3 = new Rectangle(1600, 0, 800, 480); fondo3 = new Fondo(this.Content.Load<Texture2D>("Fondo/MontanaNoche3"), rFondo3);
            rFondo4 = new Rectangle(800, 0, 800, 480); fondo4 = new Fondo(this.Content.Load<Texture2D>("Fondo/MontanaNoche4"), rFondo4);
            //____________________________________________________________________________________________________________________________
            #endregion Fondo

            miFuente = Content.Load<SpriteFont>("Fuente/Fuente");

            #region Jugador
            jugador.Initialize(
                Content.Load<Texture2D>("Personaje/CaminaIzquierda"),
                Content.Load<Texture2D>("Personaje/CaminaDerecha"),
                Content.Load<Texture2D>("Personaje/GolpeAbajoIzquierda"),
                Content.Load<Texture2D>("Personaje/GolpeAbajoDerecha"),
                Content.Load<SoundEffect>("Sonido/Golpe"),
                8, 81, 117, 1,
                5, 110, 121,120, 1, 
                100, 400);
            #endregion Personaje






        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            #region Fondo
            //Fondo_____________________________________________________________________
            if (fondo1.cuadro.X + fondo1.cuadro.Width == 0) fondo1.cuadro.X = 800;
            if (fondo2.cuadro.X + fondo2.cuadro.Width == 0) fondo2.cuadro.X = 800;
            if (fondo3.cuadro.X + fondo3.cuadro.Width == 0) fondo3.cuadro.X = 800;
            if (fondo4.cuadro.X + fondo4.cuadro.Width == 0) fondo4.cuadro.X = 800;
            fondo1.Update(); fondo2.Update(); fondo3.Update(); fondo4.Update();
            //__________________________________________________________________________
            #endregion Fondo

            #region Jugador
   
            KeyboardState  keyboard=Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left)) jugador.MoveLeft();
            if (keyboard.IsKeyDown(Keys.Right)) jugador.MoveRight();
            if (keyboard.IsKeyDown(Keys.Z) && !previoKeyboard.IsKeyDown(Keys.Z)) jugador.Hit();

            jugador.Update(gameTime);
            previoKeyboard = keyboard;

            #endregion Jugador


            Mundo(gameTime);

            base.Update(gameTime);
        }


        private void Mundo(GameTime gameTime)
        {
            if (jugador.x < 0) { jugador.x = 0; }
            if (jugador.x > graphics.PreferredBackBufferWidth) { jugador.x = 800; }
        }


  
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
         
            //TENER EN CUENTA EL ORDEN DE DIBUJAR, SE MUESTRA DEACUERDO A ESE ORDEN C: 

            #region Fondo
            //Fondo_________________________________________________________________________________________________
            fondo1.Draw(spriteBatch); fondo2.Draw(spriteBatch); fondo3.Draw(spriteBatch); fondo4.Draw(spriteBatch);
            //_______________________________________________________________________________________________________
            #endregion Fondo
            
            spriteBatch.DrawString(miFuente, "Vida:         Monedas:          Tiempo:      ", new Vector2(0, 0), Color.Orange);
          
            jugador.Draw(spriteBatch);
           
            
            spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}
