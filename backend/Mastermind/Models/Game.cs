using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Models
{
    // Begin van de gameclass
    // @todo: Deze moet je ongetwijfeld nog uitbreiden om de boel te laten werken
    public class Game
    {
        // de te raden rij
        public IRow MasterRow { get; }

        // alle rijen die de speler tot nu toe gespeeld heeft
        public List<IRow> PlayedRows {get; }

        // True als het spelletje al gewonnen is
        public bool IsWon { get; private set; }

        private readonly Random random; 

        public Game()
        {
            random = new Random();
            MasterRow = new Row(RandomColour(), RandomColour(), RandomColour(), RandomColour());
            PlayedRows = new List<IRow>(10);
            IsWon = false;
        }

        // Updaten van het spel naar aanleiding van het spelen van een rij
        public Score PlayRow(IRow newRow)
        {
            if (IsWon) throw new Exception("Game Finished");
            if (PlayedRows.Count >= 10) throw new Exception("Game Finished");

            PlayedRows.Add(newRow);
            var score = newRow.CompareToOtherRow(MasterRow);
            if (score.Same == 4)
            {
                IsWon = true;
            }
            return score;
        }

        public GameState State()
        {
            return new GameState
            {
                IsWon = IsWon,
                RowsPlayed = PlayedRows.Count,
                Answer = PlayedRows.Count > 8 ? MasterRow.Pins : null
            };
        }


        private Colour RandomColour()
        {
            var maxColour = Enum.GetNames(typeof(Colour)).Length;
            return (Colour)random.Next(0, maxColour);
        }
    }
}
