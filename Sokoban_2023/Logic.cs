using SharpDX.Direct3D9;
using System;

namespace Sokoban_2023
{
   internal class Logic
   {
      Board board;

      public Logic(Board board)
      {
         this.board = board;
      }

      public void Update()
      {
         int xStep = 0;
         int yStep = 0;

         if (InputSystem.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
         {
            xStep += 1;
         }

         if (InputSystem.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
         {
            xStep -= 1;
         }

         if (InputSystem.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
         {
            yStep += 1;
         }

         if (InputSystem.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
         {
            yStep -= 1;
         }

         if (xStep == 0 && yStep == 0) return;

         int y = -1;

         for (int i = 0; i < board.width * board.height; i++)
         {
            int x = i % board.width;
            if (x == 0) y += 1;

            switch (board.GetAt(x, y))
            {
               case Board.PLAYER_AND_GOAL:
               case Board.PLAYER:
                  Move(x, y, xStep, yStep);
                  return;
            }

         }

      }

      public bool Move(int x, int y, int xDir, int yDir)
      {
         char stepper = board.GetAt(x, y);

         int ontoX = x + xDir;
         int ontoY = y + yDir;
         char steppingOnto = board.GetAt(ontoX, ontoY);

         switch (steppingOnto)
         {
            case Board.WALL:
            case Board.UNAVALIABLE:
               return false;

            case Board.GROUND:
               board.SetAt(x, y, char.IsUpper(stepper) ? Board.GOAL : Board.GROUND);
               board.SetAt(ontoX, ontoY, char.ToLower(stepper));
               return true;

            case Board.GOAL:
               board.SetAt(x, y, char.IsUpper(stepper) ? char.ToLower(stepper) : Board.GROUND);
               board.SetAt(ontoX, ontoY, char.ToUpper(stepper));
               return true;

            case Board.BOX_AND_GOAL:
            case Board.BOX:
               if (Move(ontoX, ontoY, xDir, yDir) == true)
               {
                  board.SetAt(x, y, char.IsUpper(stepper) ? Board.GOAL : Board.GROUND);
                  board.SetAt(ontoX, ontoY, char.IsUpper(steppingOnto) ? char.ToUpper(stepper) : char.ToLower(stepper));
                  return true;
               }
               return false;

            default:
               Console.WriteLine($"non-implemented logic trying to step onto: {steppingOnto}");
               return false;
         }

      }


   }
}
