using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{
    public interface IPlayAudio
    {
      void PlaySFX(string sfx, bool isLooping = true);
      void StopSFX(string sfx);
    }
}
