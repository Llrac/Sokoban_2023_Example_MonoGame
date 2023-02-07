using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Sokoban_2023
{
   internal class Editor
   {

      private Cursor cursor;
      private Board board;
      private enum Holding { NOTHING, WALL, BOX, GOAL, GROUND, PLAYER };
      private Holding holding;
      private Holding prevHolding;

      public Editor(Cursor cursor, Board board)
      {
         this.cursor = cursor;
         this.board = board;
         holding = Holding.NOTHING;
      }

      public void Update()
      {
         if(InputSystem.IsKeyHeld(Keys.LeftShift))
         {
            if (InputSystem.IsKeyPressed(Keys.Right))
            {
               board.AdjustMatrix(1,0);
            }
            if (InputSystem.IsKeyPressed(Keys.Up))
            {
               board.AdjustMatrix(0,-1);
            }
            if (InputSystem.IsKeyPressed(Keys.Down))
            {
               board.AdjustMatrix(0, 1);
            }
            if (InputSystem.IsKeyPressed(Keys.Left))
            {
               board.AdjustMatrix(-1, 0);
            }
         }

         if (InputSystem.IsKeyHeld(Keys.LeftShift))
         {
            if (InputSystem.IsKeyPressed(Keys.D))
            {
               board.ContractLevel(1, 0);          
               board.AdjustMatrix(-1, 0);
            }
            if (InputSystem.IsKeyPressed(Keys.W))
            {
               board.ContractLevel(0, 1);
               board.AdjustMatrix(0, -1);
            }
            if (InputSystem.IsKeyPressed(Keys.S))
            {
               board.ContractLevel(0, 1);
            }
            if (InputSystem.IsKeyPressed(Keys.A))
            {
               board.ContractLevel(1, 0);
            }
         }
         else
         {
            if (InputSystem.IsKeyPressed(Keys.D))
            {
               board.ExtendLevel(1, 0);
            }
            if (InputSystem.IsKeyPressed(Keys.W))
            {
               board.ExtendLevel(0, 1);
               board.AdjustMatrix(0, 1);
            }
            if (InputSystem.IsKeyPressed(Keys.S))
            {
               board.ExtendLevel(0, 1);
            }
            if (InputSystem.IsKeyPressed(Keys.A))
            {
               board.ExtendLevel(1, 0);
               board.AdjustMatrix(1, 0);
            }
         }



         if (InputSystem.IsKeyPressed(Keys.D1))
         {
            holding = Holding.NOTHING;
         }
         if (InputSystem.IsKeyPressed(Keys.D2))
         {
            holding = Holding.WALL;
         }
         if (InputSystem.IsKeyPressed(Keys.D3))
         {
            holding = Holding.PLAYER;
         }
         if (InputSystem.IsKeyPressed(Keys.D4))
         {
            holding = Holding.BOX;
         }
         if (InputSystem.IsKeyPressed(Keys.D5))
         {
            holding = Holding.GOAL;
         }
         if (InputSystem.IsKeyPressed(Keys.D6))
         {
            holding = Holding.GROUND;
         }

         if (prevHolding != holding)
         {
            prevHolding = holding;
            switch (holding)
            {
               case Holding.NOTHING:
                  cursor.ResetCursor();
                  break;
               case Holding.WALL:
                  cursor.SetCursorSprite(board.wall);
                  break;
               case Holding.BOX:
                  cursor.SetCursorSprite(board.box);
                  break;
               case Holding.GOAL:
                  cursor.SetCursorSprite(board.goal);
                  break;
               case Holding.GROUND:
                  cursor.SetCursorSprite(board.ground);
                  break;
               case Holding.PLAYER:
                  cursor.SetCursorSprite(board.player);
                  break;

            }
         }

         if (InputSystem.IsKeyPressed(Keys.Enter))
         {
            switch (holding)
            {
               case Holding.WALL:
                  board.SetAt(cursor.x, cursor.y, Board.WALL);
                  break;
               case Holding.BOX:
                  board.SetAt(cursor.x, cursor.y, Board.BOX);
                  break;
               case Holding.GOAL:
                  board.SetAt(cursor.x, cursor.y, Board.GOAL);
                  break;
               case Holding.GROUND:
                  board.SetAt(cursor.x, cursor.y, Board.GROUND);
                  break;
               case Holding.PLAYER:
                  board.SetAt(cursor.x, cursor.y, Board.PLAYER);
                  break;

            }
         }

      }
   }
}
