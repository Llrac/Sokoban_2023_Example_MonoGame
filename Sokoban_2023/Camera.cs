using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023
{
   public class Camera
   {
      private Board board;

      public Camera(Board board)
      {
         this.board = board;
      }

      public int GetXoffset()
      {
         int offset = Sokoban.GAME_WIDTH / 2;
         offset -= board.width * Sokoban.CELL_SIZE / 2;
         return offset;
      }

      public int GetYOffset()
      {
         int offset = Sokoban.GAME_HEIGHT / 2;
         offset -= board.height * Sokoban.CELL_SIZE / 2;
         return offset;
      }

      public Vector2 GetOffset()
      {
         return new Vector2(GetXoffset(), GetYOffset());
      }

   }
}
