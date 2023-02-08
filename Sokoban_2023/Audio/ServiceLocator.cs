using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{
    public static class ServiceLocator
    {
      private static IPlayAudio audioProvider;
      
      public static IPlayAudio GetAudioProvider()
      {
         audioProvider ??= new NullAudioService();
         return audioProvider;
      }

      public static void SetAudioProvider(IPlayAudio provider)
      {
         audioProvider = provider;
      }

    }
}
