using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Input;
using System;
using Sokoban_2023.Command;

namespace Sokoban_2023
{
    internal class Logic
   {
   private Board board;

      public Logic(Board board)
      {
         this.board = board;
      }

      public void Update()
      {
         int xStep = 0;
         int yStep = 0;

         if (InputSystem.IsKeyPressed(Keys.Right))
         {
            xStep += 1;
         }

         if (InputSystem.IsKeyPressed(Keys.Left))
         {
            xStep -= 1;
         }

         if (InputSystem.IsKeyPressed(Keys.Down))
         {
            yStep += 1;
         }

         if (InputSystem.IsKeyPressed(Keys.Up))
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

      public void Move(int x, int y, int xDir, int yDir)
      {
         CheckpointCommand checkpoint = new CheckpointCommand();
         History.Add(checkpoint);

         MoveCommand moveCmd = new MoveCommand(x, y, xDir, yDir, board);
         bool result = moveCmd.Execute();
         if (result)
         {
            History.Add(moveCmd);
         }
      }


   }
}
