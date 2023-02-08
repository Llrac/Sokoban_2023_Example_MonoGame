namespace Sokoban_2023.Commands
{
   public abstract class Command
    {
        public abstract bool Execute();
        public abstract void Undo();
    }
}
