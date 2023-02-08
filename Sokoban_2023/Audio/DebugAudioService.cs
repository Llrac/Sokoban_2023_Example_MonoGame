using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{
    internal class DebugAudioService : IPlayAudio
    {
        public void PlaySFX(string sfx, bool isLooping = true)
        {
         Console.WriteLine($"playing {sfx}");
        }

        public void StopSFX(string sfx)
        {
        }
    }
}
