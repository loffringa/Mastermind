using System;
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
        public void TestTheWinnerTakesAll()
        {
            var game = new Game();
            var masterrow = game.MasterRow;
            game.PlayRow(masterrow);
            Assert.IsTrue(game.IsWon);
        }

        [Test]
        public void TestNotWonYet()
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
                return (Colour) colour+1;
            }
            else
            {
                return (Colour)colour-1;
            }
        }
    }
}