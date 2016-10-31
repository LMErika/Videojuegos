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

        int cuurentBackground;
        List<Texture2D> backgrpunds;
        List<Texture2D> segmentos;
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
            
            height=550;
            width = 800;
             graphics.PreferredBackBufferHeight=height;
             graphics.PreferredBackBufferWidth=width;
        }

 
        protected override void Initialize()
        {

           jugador = new Jugador();

           #region Mundo
           cuurentBackground = 0;
           backgrpunds = new List<Texture2D>();
           segmentos = new List<Texture2D>();
           #endregion Mundo

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

            #region mundo
            for(int i=1; i<=4; i++){
                backgrpunds.Add(Content.Load<Texture2D>("Fondo000/Fondo"+i.ToString()));
                //if(i==2) segmentos.Add(Content.Load<Texture2D>("Segmento/Objeto" + i.ToString()));
           
            }
           #endregion mundo


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
                100, height-100,     15,
                
                Content.Load<Texture2D>("Poder/PoderDerecha"),
                Content.Load<Texture2D>("Poder/PoderIzquierda"), Content.Load<SoundEffect>("Sonido/Poder"));
            #endregion Personaje



            /**/


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
            if (keyboard.IsKeyDown(Keys.X) && !previoKeyboard.IsKeyDown(Keys.X)) jugador.Poder();
    

            jugador.Update(gameTime);
            previoKeyboard = keyboard;

            #endregion Jugador


            Mundo(gameTime);


            //checkWorld(gameTime);

            base.Update(gameTime);
        }





        private void Mundo(GameTime gameTime)
        {
        //    if (jugador.x < 0) { jugador.x = 0; }
        //    if (jugador.x > graphics.PreferredBackBufferWidth) { jugador.x = 800; }
            if (cuurentBackground == 0 && jugador.X < 0)
            {
                jugador.X = 0;
            }
            if (cuurentBackground == 0 && jugador.X>width)
            {
                jugador.X = 0;
                cuurentBackground++;
            }
            if (cuurentBackground == 1 && jugador.X < 0)
            {
                jugador.X = width;
                cuurentBackground--;
            }
            if (cuurentBackground == 1 && jugador.X > width)
            {
                jugador.X = 800;
            }


        
        }


  
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
         
            //TENER EN CUENTA EL ORDEN DE DIBUJAR, SE MUESTRA DEACUERDO A ESE ORDEN C: 

            #region Fondo
            //Fondo_________________________________________________________________________________________________
            //fondo1.Draw(spriteBatch); fondo2.Draw(spriteBatch); fondo3.Draw(spriteBatch); fondo4.Draw(spriteBatch);
            //_______________________________________________________________________________________________________
            #endregion Fondo

            spriteBatch.Draw(backgrpunds[cuurentBackground],new Vector2(0,0), Color.White);
            //spriteBatch.Draw(segmentos[cuurentBackground], new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(miFuente, "Vida:         Monedas:          Tiempo:      ", new Vector2(0, 0), Color.Orange);
          
            jugador.Draw(spriteBatch);
           
            
            spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}
