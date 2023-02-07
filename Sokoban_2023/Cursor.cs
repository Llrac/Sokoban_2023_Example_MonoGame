using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023
{
   internal class Cursor
   {
      private ContentManager content;

      public int x { get; private set; }
      public int y { get; private set; }
      private Texture2D basicCursor;
      private Texture2D currentCursor;

      public Cursor(ContentManager content)
      {
         this.content = content;
         basicCursor = content.Load<Texture2D>("Sprites/cursor");
         currentCursor = basicCursor;
      }

      public void SetCursorSprite(Texture2D tex)
      {
         currentCursor = tex;
      }

      public void ResetCursor()
      {
         currentCursor = basicCursor;
      }

      public void Draw(SpriteBatch batch, Vector2 camOffset)
      {
         Vector2 position = new Vector2(x * Sokoban.CELL_SIZE, y * Sokoban.CELL_SIZE);
         position += camOffset;
         batch.Draw(currentCursor, position, currentCursor == basicCursor ? Color.White : new Color(1, 1, 1, 0.4f));
      }

      internal void Update()
      {
         if (InputSystem.IsKeyHeld(Keys.LeftShift)) return;

         if (InputSystem.IsKeyPressed(Keys.Right))
         {
            x += 1;
         }
         if (InputSystem.IsKeyPressed(Keys.Left))
         {
            x -= 1;
         }
         if (InputSystem.IsKeyPressed(Keys.Up))
         {
            y -= 1;
         }
         if (InputSystem.IsKeyPressed(Keys.Down))
         {
            y += 1;
         }
      }
   }
}
