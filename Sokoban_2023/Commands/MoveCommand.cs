using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023.Commands
{
    public class MoveCommand : Command
    {
        private int x;
        private int y;

        private char stepper;
        private char steppingOnto;

        private int xDir;
        private int yDir;


        private Board board;

        public MoveCommand(int x, int y, int xDir, int yDir, Board board)
        {
            this.x = x;
            this.y = y;
            this.xDir = xDir;
            this.yDir = yDir;
            this.board = board;

            stepper = board.GetAt(x, y);
            steppingOnto = board.GetAt(x + xDir, y + yDir);
        }

        public override bool Execute()
        {

            int ontoX = x + xDir;
            int ontoY = y + yDir;

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

                    MoveCommand recursiveMove = new MoveCommand(ontoX, ontoY, xDir, yDir, board);
                    bool result = recursiveMove.Execute();

                    if (result)
                    {
                        History.Add(recursiveMove);
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

        public override void Undo()
        {
            board.SetAt(x, y, stepper);
            board.SetAt(x + xDir, y + yDir, steppingOnto);
        }
    }
}
