using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using System;

namespace Sokoban_2023
{
   public class Board
   {
      public int width { get; private set; }
      public int height { get; private set; }

      private char[,] level;

      public  readonly  Texture2D ground;
      public  readonly  Texture2D wall;
      public  readonly  Texture2D box;
      public  readonly  Texture2D goal;
      public  readonly  Texture2D player;
      private readonly  Texture2D black;

      public const char GROUND      = 'c';
      public const char WALL        = 'w';
      public const char GOAL        = 'g';
      public const char BOX         = 'b';
      public const char PLAYER      = 'p';
      public const char UNAVALIABLE = 'x';

      public const char BOX_AND_GOAL    = 'B';
      public const char PLAYER_AND_GOAL = 'P';

      public Board(ContentManager c)
      {
         ground = c.Load<Texture2D>("Sprites/ground");
         box    = c.Load<Texture2D>("Sprites/box");
         wall   = c.Load<Texture2D>("Sprites/wall");
         goal   = c.Load<Texture2D>("Sprites/goal");
         player = c.Load<Texture2D>("Sprites/player");
         black  = c.Load<Texture2D>("Sprites/black");
      }

      public void LoadLevel(char[,] level)
      {
         width  = level.GetLength(0);
         height = level.GetLength(1);
         this.level = RotateArray(level);
      }

      public void ExtendLevel(int xAmount, int yAmount)
      {
         char[,] newlvl = new char[width + xAmount, height + yAmount];

         for (int x = 0; x < width + xAmount; x++)
         {
            for (int y = 0; y < height + yAmount; y++)
            {
               newlvl[x, y] = GROUND;
            }
         }

         for (int x = 0; x < width; x++)
         {
            for (int y = 0; y < height; y++)
            {
               newlvl[x, y] = level[x,y];
            }
         }

         level = newlvl;
         width = newlvl.GetLength(0);
         height = newlvl.GetLength(1);
      }

      public void ContractLevel(int xAmount, int yAmount)
      {
         char[,] newlvl = new char[width - xAmount, height - yAmount];
    
         for (int x = 0; x <  width - xAmount; x++)
         {
            for (int y = 0; y < height - yAmount; y++)
            {
               newlvl[x, y] = level[x, y];
            }
         }

         level = newlvl;
         width = newlvl.GetLength(0);
         height = newlvl.GetLength(1);
      }

      public void AdjustAllPieces( int x, int y)
      {
         int rowCount = level.GetLength(0);
         int colCount = level.GetLength(1);

         char[,] result = new char[rowCount, colCount];

         for (int i = 0; i < rowCount; i++)
         {
            for (int j = 0; j < colCount; j++)
            {
               result[i, j] = level[(i + rowCount - x) % rowCount, (j + colCount - y) % colCount];
            }
         }

         level = result;
         width = result.GetLength(0);
         height = result.GetLength(1);
      }


      static char[,] RotateArray(char[,] input)
      {
         int rows = input.GetLength(0);
         int cols = input.GetLength(1);

         char[,] result = new char[cols, rows];

         for (int i = 0; i < rows; i++)
         {
            for (int j = 0; j < cols; j++)
            {
               result[j, i] = input[i, j];
            }
         }

         return result;
      }

      public char GetAt(int x, int y)
      {
         if (GetIsInsideBoard(x, y)) return level[x, y];

         return UNAVALIABLE;
      }

      public void SetAt(int x, int y, char c)
      {
         level[x, y] = c;
      }

      public bool GetIsInsideBoard(int x, int y)
      {
         return (x < width && x >= 0 && y < height && y >= 0);
      }

      public void Draw(SpriteBatch batch, Vector2 camOffset)
      {
         int y = -1;
         for (int i = 0; i < width * height; i++)
         {
            int x = i % width;
            if (x == 0) y += 1;

            Vector2 position = new Vector2(x * Sokoban.CELL_SIZE, y * Sokoban.CELL_SIZE);
            position += camOffset;

            batch.Draw(ground, position, Color.White);

            if ((x + y) % 2 == 0)
            {
               batch.Draw(black, position, new Color(1, 1, 1, alpha: 0.15f));
            }
         }

         y = -1;

         for (int i = 0; i < width * height; i++)
         {
            int x = i % width;
            if (x == 0) y += 1;

            Vector2 position = new Vector2(x * Sokoban.CELL_SIZE, y * Sokoban.CELL_SIZE);
            position += camOffset;

            Vector2 playerOffset = new Vector2(0, -player.Height / 2);

            switch (level[x, y])
            {
               case BOX:
                  batch.Draw(box, position, Color.White);
                  break;
               case WALL:
                  batch.Draw(wall, position, Color.White);
                  break;
               case PLAYER:
                  batch.Draw(player, position + playerOffset, Color.White);
                  break;
               case GOAL:
                  batch.Draw(goal, position, Color.White);
                  break;
               case PLAYER_AND_GOAL:
                  batch.Draw(goal, position, Color.White);
                  batch.Draw(player, position + playerOffset, Color.White);
                  break;
               case BOX_AND_GOAL:
                  batch.Draw(goal, position, Color.White);
                  batch.Draw(box, position, Color.White);
                  break;

            }
         }
      }
   }
}