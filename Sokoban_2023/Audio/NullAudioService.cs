using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{
    internal class NullAudioService : IPlayAudio
    {
        public void PlaySFX(string sfx, bool isLooping = true)
        {
        }

        public void StopSFX(string sfx)
        {
        }
    }
}
