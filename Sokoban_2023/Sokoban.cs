using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Sokoban_2023
{
   public class Sokoban : Game
   {
      private GraphicsDeviceManager _graphics;
      private SpriteBatch spritebatch;
      private enum GAMESTATE { GAME, DEBUG };
      private GAMESTATE currentGameState;
      private Board board;
      private Logic logic;
      private Cursor cursor;
      private Camera camera;
      private Editor editor;

      public static int CELL_SIZE = 16;

      public const int GAME_WIDTH = 320;
      public const int GAME_HEIGHT = 180;
      public const int GAME_UPSCALE_FACTOR = 4;

      public Sokoban()
      {
         _graphics = new GraphicsDeviceManager(this);
         Content.RootDirectory = "Content";
         IsMouseVisible = false;
      }

      protected override void Initialize()
      {

         _graphics.PreferredBackBufferHeight = GAME_HEIGHT * GAME_UPSCALE_FACTOR;
         _graphics.PreferredBackBufferWidth = GAME_WIDTH * GAME_UPSCALE_FACTOR;
         _graphics.ApplyChanges();

         base.Initialize();
         board = new(Content);
         cursor = new(Content);

         char[,] sampleLevel = new char[5, 5]
         {
            {'c','c','c','c','c'},
            {'c','g','c','c','c'},
            {'c','c','p','b','c'},
            {'c','c','c','c','c'},
            {'c','c','c','c','c'}
         };

         board.LoadLevel(sampleLevel);

         logic = new(board);
         camera = new(board);
         editor = new(cursor, board);
      }

      protected override void LoadContent()
      {
         spritebatch = new SpriteBatch(GraphicsDevice);
      }

      protected override void Update(GameTime gameTime)
      {
         if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
         if (Keyboard.GetState().IsKeyDown(Keys.F1)) currentGameState = GAMESTATE.GAME;
         if (Keyboard.GetState().IsKeyDown(Keys.F2)) currentGameState = GAMESTATE.DEBUG;

         InputSystem.Update();

         switch (currentGameState)
         {
            case GAMESTATE.GAME:
               logic.Update();
               break;
            case GAMESTATE.DEBUG:
               editor.Update();
               cursor.Update();
               break;
         }

         base.Update(gameTime);
      }

      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.CornflowerBlue);

         Matrix matrix = Matrix.CreateScale(GAME_UPSCALE_FACTOR);
         spritebatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: matrix);

         board.Draw(spritebatch, camera.GetOffset());
        
         switch (currentGameState)
         {
            case GAMESTATE.DEBUG:
               cursor.Draw(spritebatch, camera.GetOffset());
               break;
         }

         spritebatch.End();

         base.Draw(gameTime);
      }
   }
}