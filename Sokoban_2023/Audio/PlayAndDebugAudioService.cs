using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{


    internal class PlayAndDebugAudioService : IPlayAudio
    {
       private DebugAudioService debug;
       private BasicAudioService basic;

        public PlayAndDebugAudioService(ContentManager manager)
        {
         debug = new DebugAudioService();
         basic = new BasicAudioService(manager);
        }

        public void PlaySFX(string sfx, bool isLooping = true)
        {
         debug.PlaySFX(sfx);
         basic.PlaySFX(sfx);
        }

        public void StopSFX(string sfx)
        {
        }
    }
}
