namespace Sokoban_2023.Command
{
   public abstract class Command
    {
        public abstract bool Execute();
        public abstract void Undo();
    }
}
