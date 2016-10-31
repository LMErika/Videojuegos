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
    public class Music
    {
     

public static void PlayMusic(Song gameplayMusic)
{
    try
    {
        MediaPlayer.Play(gameplayMusic);
        MediaPlayer.IsRepeating = true;
    }
    catch { }
}


        public static void Stop()
        {
          MediaPlayer.Stop();

        }



    }
}
