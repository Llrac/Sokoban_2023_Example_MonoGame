using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_2023.Commands;

namespace Sokoban_2023
{
    public static class History
    {
      private static Stack<Command> history;

      public static void Add(Command c)
      {
         history ??= new Stack<Command>();
         history.Push(c);
      }

      public static void Undo()
      {
         if (history == null || history.Count == 0) return;

         Command newest = history.Pop();

         newest.Undo();

         if(history.Count > 0 && history.Peek().GetType() != typeof(CheckpointCommand))
         {
            Undo();
         }
      }

        internal static void Update()
        {
         if(InputSystem.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
         {
            Undo();
         }   
        }
    }
}
