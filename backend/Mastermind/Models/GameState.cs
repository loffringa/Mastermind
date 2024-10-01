using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class GameState
    {
        public bool IsWon { get; set; }
        public int RowsPlayed { get; set; }
        public IPin[] Answer { get; set; }
    }
}
