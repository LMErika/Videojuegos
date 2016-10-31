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
    public class Jugador
    {

        private Texture2D WalkLeft;       private Texture2D WalkRight;
        private Texture2D HitLeft;        private Texture2D HitRight;
        private SoundEffect HitSound;
        private int frameCountWalk;
        private int frameWidthWalk;       private int frameHeightWalk;
        private float scaleWalk;
        private int frameCountAttack;
        private int frameWidthAttack;        private int frameHeightAttack;
        private int frameTimeAttack;
        private float scaleAttack;
        private int currentFrameWalk;
        private int currentFrameAttack;
        private Rectangle sourceRect = new Rectangle();        private Rectangle destinatioRect = new Rectangle();
        public int x;     private int y;
        private Direccion direction;

        private int speed;
        private bool hit;
        //------------------------------------------------------------
        private List<Poder> poderes;
        private int nPoder;
        private Texture2D PoderLeft; private Texture2D PoderRight;
        private SoundEffect GolpeSound;


        private int elapsedTime;

        public int X
        {
            get { return x; }
            set { x = value; }
        }


        
        public void Initialize(Texture2D WalkLeft,
            Texture2D WalkRight, Texture2D HitLeft,
            Texture2D HitRight,SoundEffect HitSound,
            int frameCountWalk, int frameWidthWalk, int frameHeightWalk,
            float scaleWalk,
            int frameCountAttack, int frameWidthAttack,
            int frameHeightAttack,int frameTimeAttack,
            float scaleAttack,
            int x, int y, 
            int nPoder,Texture2D PoderLeft,Texture2D PoderRight,SoundEffect GolpeSound)
        {
            this.WalkLeft = WalkLeft;
            this.WalkRight = WalkRight;
            this.HitRight = HitRight;
            this.HitLeft = HitLeft;
            this.frameCountWalk = frameCountWalk;
            this.currentFrameWalk = 0;
            this.currentFrameAttack = 0;
            this.scaleWalk = scaleWalk;
            this.scaleAttack = scaleAttack;
            this.frameWidthWalk = frameWidthWalk;
            this.frameHeightWalk = frameHeightWalk;
            this.frameTimeAttack = frameTimeAttack;
            this.frameCountAttack = frameCountAttack;
            this.frameWidthAttack = frameWidthAttack;
            this.frameHeightAttack = frameHeightAttack;
            this.HitSound = HitSound;
            this.x = x;
            this.y = y;
            this.direction = Direccion.LeftRight;
            this.speed = 3;
            this.hit = false;
            //----------------------------------------------------------------------------------------
            this.nPoder = nPoder;
            this.PoderLeft = PoderLeft;
            this.PoderRight = PoderRight;
            this.poderes = new List<Poder>();
            this.GolpeSound = GolpeSound;

        }


        public void Update(GameTime gameTime)
        {

            if (!hit)
            {
                sourceRect = new Rectangle(currentFrameWalk * frameWidthWalk, 0, frameWidthWalk, frameHeightWalk);
                destinatioRect = new Rectangle(
                x - (int)(frameWidthWalk * scaleWalk) / 2,
                y - (int)(frameHeightWalk * scaleWalk) / 2,
                (int)(frameWidthWalk * scaleWalk),
                (int)(frameHeightWalk * scaleWalk));

            }

            else
            {
                elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                // Si elapsedTime es mayor que frame time debemos cambiar de imagen
                if (elapsedTime > frameTimeAttack)
                {
                    // Movemos a la siguiente imagen
                    currentFrameAttack++;
                    // Si currentFrame es igual al frameCount hacemos reset currentFrame a cero
                    if (currentFrameAttack == frameCountAttack)
                    {
                        currentFrameAttack = 0;
                        // Si no queremos repetir la animacion asignamos Active a falso
                        hit = false;
                    }
                    // Reiniciamos elapsedTime a cero
                    elapsedTime = 0;
                }
                // Tomamos la imagen correcta multiplicando el currentFrame  por el ancho de la imagen
                sourceRect = new Rectangle(currentFrameAttack * frameWidthAttack,
                    0, frameWidthAttack, frameHeightAttack);

                // Actualizamos la posicion de la imagen en caso que esta se desplace por la pantalla
                destinatioRect = new Rectangle(
                   x - (int)(frameWidthAttack * scaleAttack) / 2,
                   y - (int)(frameHeightAttack * scaleAttack) / 2,
                    (int)(frameWidthAttack * scaleAttack),
                    (int)(frameHeightAttack * scaleAttack));
            }

            UpdatePoder(gameTime);
        }
            private void UpdatePoder(GameTime gameTime)
            {
                foreach (Poder  poder in poderes)
	            {
		            poder.Update(gameTime);
	            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hit)
            {
                if (direction == Direccion.LeftRight)
                {
                    spriteBatch.Draw(WalkRight, destinatioRect, sourceRect, Color.White);
                }

                else
                {
                    spriteBatch.Draw(WalkLeft, destinatioRect, sourceRect, Color.White);

                }
            }


            else

            {
                if (direction == Direccion.LeftRight)
                {
                    spriteBatch.Draw(HitRight, destinatioRect, sourceRect, Color.White);
                }

                else
                {
                    spriteBatch.Draw(HitLeft, destinatioRect, sourceRect, Color.White);

                }

            }
            DrawPoder(spriteBatch);
        }

            public void DrawPoder(SpriteBatch spriteBacht)
            {

                foreach (Poder poder in poderes)
                {
                    poder.Draw(spriteBacht); 
                }
            }
         



        //.----------------------------------------------------------------------------------


        internal void MoveLeft() {

            if (hit) return;
            direction = Direccion.RightLeft;
            x -= speed;


            if (x % 5 == 0) currentFrameWalk--;
            if (currentFrameWalk <= 0)
            {
                currentFrameWalk = frameCountWalk;
            }
        
        }

        internal void MoveRight() {

            if (hit) return;
            direction = Direccion.LeftRight;
            x += speed;
            
            if(x% 5==0)currentFrameWalk++;

            if (currentFrameWalk >= frameCountWalk)
            {
                currentFrameWalk = 0;
            }

        }

        internal void Hit()
        {
            //currentFrameAttack = 0;
            HitSound.Play();
            hit = true;
        }

        internal void Poder()
        {
            if (nPoder <= 0) return;
            
                Poder poder = new Poder();
                poder.Initialaze(PoderLeft, PoderRight, direction, x, y);
                GolpeSound.Play();
                poderes.Add(poder);
                nPoder--;
            
        }


    }
}
