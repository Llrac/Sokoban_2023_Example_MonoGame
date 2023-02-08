using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Audio
{
    internal class BasicAudioService : IPlayAudio
    {
        private ContentManager manager;

      private Dictionary<string, SoundEffect> library;

        public BasicAudioService(ContentManager c)
        {
         manager = c;
        }

        public void PlaySFX(string sfx, bool isLooping = true)
        {

         library ??= new Dictionary<string, SoundEffect>();
         SoundEffect sound;
         if (library.ContainsKey(sfx))
         {
            sound = library[sfx];
         }
         else
         {
            sound = manager.Load<SoundEffect>($"SFX/{sfx}");
            library.Add(sfx, sound);
         }

         sound.Play();
        }

        public void StopSFX(string sfx)
        {
        }
    }
}
