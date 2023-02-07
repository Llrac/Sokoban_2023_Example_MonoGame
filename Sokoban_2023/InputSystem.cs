using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023
{
   internal static class InputSystem
   {
      private static KeyboardState current;
      private static KeyboardState previous;

      public static void Update()
      {
         previous = current;
         current = Keyboard.GetState();
      }

      public static bool IsKeyHeld(Keys key)
      {
         return current.IsKeyDown(key);
      }

      public static bool IsKeyPressed(Keys key)
      {
         return current.IsKeyDown(key) && !previous.IsKeyDown(key);
      }

   }
}
