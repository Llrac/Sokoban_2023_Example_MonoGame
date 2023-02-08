using Sokoban_2023.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2023
{
    internal class CheckpointCommand : Command
    {
        public override bool Execute()
        {
         return true;
        }

        public override void Undo()
        {
        }
    }
}
