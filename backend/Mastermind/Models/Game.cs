using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Models
{
    // Begin van de gameclass
    public class Game
    {
        // De te raden rij
        public IRow MasterRow { get; }

        // Alle rijen die de speler tot nu toe gespeeld heeft
        public List<IRow> PlayedRows { get; }

        // True als het spelletje al gewonnen is
        public bool IsWon { get; private set; }

        // True als er een gelijkspel is
        public bool IsTie { get; private set; }

        // Globale variabele om te kijken of je verloren hebt
        public bool IsLost => PlayedRows.Count >= MaxAttempts && !IsWon;

        // Het maximaal aantal pogingen dat de speler kan doen
        public int MaxAttempts { get; } = 10;

        // Board property om de gespeelde rijen op te halen als het "bord"
        public List<IRow> Board => PlayedRows;

        private readonly Random random;
        private List<Score> playerScores;  // List to store scores for both players

        public Game()
        {
            random = new Random();
            MasterRow = new Row(RandomColour(), RandomColour(), RandomColour(), RandomColour());
            PlayedRows = new List<IRow>(MaxAttempts);
            IsWon = false;
            IsTie = false;
            playerScores = new List<Score>();  // Initialize the list to store player scores
        }

        // Updaten van het spel naar aanleiding van het spelen van een rij
        public Score PlayRow(IRow newRow)
        {
            if (IsWon || IsLost) throw new Exception("Game Finished");

            PlayedRows.Add(newRow);
            var score = newRow.CompareToOtherRow(MasterRow);
            playerScores.Add(score);  // Store the score for this player

            // Controleer of het spel gewonnen is
            if (score.Same == 4)
            {
                // Controleer of er al een vorige overwinning (score van 4) is behaald
                if (playerScores.Count >= 2 && playerScores[0].Same == 4 && playerScores[1].Same == 4)
                {
                    IsTie = true;  // Stel gelijkspel in als beide spelers een score van 4 hebben behaald
                }
                else
                {
                    IsWon = true;
                }
            }

            return score;
        }

        public GameState State()
        {
            return new GameState
            {
                IsWon = IsWon,
                RowsPlayed = PlayedRows.Count,
                Answer = PlayedRows.Count > 8 ? MasterRow.Pins : null  // Toont het antwoord na 8 pogingen
            };
        }

        // Voeg de willekeurige kleur toe om een kleur te genereren voor de geheime code
        private Colour RandomColour()
        {
            var maxColour = Enum.GetNames(typeof(Colour)).Length - 1;
            return (Colour)random.Next(0, maxColour);  // Exclude Colour.None door de range te beperken
        }
    }
}
