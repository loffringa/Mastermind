using System;
using System.Linq;
using Mastermind.Models;
using NUnit.Framework;

namespace MastermindTest.Tests
{
    public class GameTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTheWinnerTakesAll() // TCA004
        {
            var game = new Game();
            var masterrow = game.MasterRow;
            game.PlayRow(masterrow);
            Assert.IsTrue(game.IsWon);
        }

        [Test]
        public void TestNotWonYet() // TCA012
        {
            var game = new Game();
            var masterrow = game.MasterRow;
            // zeker weten dat het een andere rij is (masterrow is random!)
            var nextTry = new Row(NextColour(masterrow.Pins[0].Colour)
                , NextColour(masterrow.Pins[0].Colour)
                , NextColour(masterrow.Pins[0].Colour)
                , NextColour(masterrow.Pins[0].Colour));
            game.PlayRow(nextTry);
            Assert.IsFalse(game.IsWon);
        }

        private Colour NextColour(Colour colour)
        {
            if (colour != Colour.Yellow)
            {
                return (Colour)colour + 1;
            }
            else
            {
                return (Colour)colour - 1;
            }
        }

        // <----- Mijn eigen testcases ----->

        [Test]
        public void TestSecretCodeGeneration() // TCA001
        {
            var game = new Game();
            var masterRow = game.MasterRow;

            Assert.AreEqual(4, masterRow.Pins.Length, "De geheime code moet uit vier kleuren bestaan.");
            Assert.That(masterRow.Pins.Select(pin => pin.Colour), Is.All.InstanceOf<Colour>(), "De geheime code moet alleen kleuren bevatten.");
            Assert.That(masterRow.Pins.Select(pin => pin.Colour).Distinct().Count() <= 4, "De geheime code moet duplicaten toestaan uit zes beschikbare kleuren.");
        }


        [Test]
        public void TestGameEndWhenCodeCracked() // TCA004
        {
            var game = new Game();
            var masterRow = game.MasterRow;
            game.PlayRow(masterRow);

            Assert.IsTrue(game.IsWon, "Het spel moet eindigen als de geheime code is gekraakt.");
        }


        [Test]
        public void TestGameEndWithTie() // TCA009
        {
            var game = new Game();

            var row1 = new Row(Colour.Red, Colour.Green, Colour.Blue, Colour.Yellow);
            var row2 = new Row(Colour.Red, Colour.Green, Colour.Blue, Colour.Yellow);

            // Speel bijde rijen
            game.PlayRow(row1);
            game.PlayRow(row2);

            // We check if both players have the same score
            var score1 = row1.CompareToOtherRow(game.MasterRow);
            var score2 = row2.CompareToOtherRow(game.MasterRow);

            // Check if both players achieved the same score
            var isTie = score1.Same == score2.Same;

            // Assert that the game ends in a tie if both players have the same score
            Assert.IsTrue(isTie, "Het spel moet in een gelijkspel eindigen als beide spelers dezelfde score hebben.");
        }

    }
}