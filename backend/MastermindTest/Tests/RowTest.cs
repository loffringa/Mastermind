using Mastermind.Models;
using NUnit.Framework;
using System.Linq;

namespace MastermindTest.Tests
{
    public class RowTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllBlacks() // TCA013
        {
            var row1 = new Row(Colour.Black, Colour.Black, Colour.Black, Colour.Black);
            var row2 = new Row(Colour.Black, Colour.Black, Colour.Black, Colour.Black);
            Assert.AreEqual(4, row1.CompareToOtherRow(row2).Same);
            Assert.AreEqual(0, row1.CompareToOtherRow(row2).SameColour);
        }

        [Test]
        public void TestBlackOrWhite() // TCA014
        {
            var row1 = new Row(Colour.Black, Colour.Black, Colour.Black, Colour.Black);
            var row2 = new Row(Colour.White, Colour.White, Colour.White, Colour.White);
            Assert.AreEqual(0, row1.CompareToOtherRow(row2).Same);
            Assert.AreEqual(0, row1.CompareToOtherRow(row2).SameColour);
        }

        [Test]
        public void TestTrueColours() // TCA015
        {
            var row1 = new Row(Colour.Blue, Colour.Green, Colour.Red, Colour.Yellow);
            var row2 = new Row(Colour.Green, Colour.Red, Colour.Yellow, Colour.Blue);
            Assert.AreEqual(0, row1.CompareToOtherRow(row2).Same);
            Assert.AreEqual(4, row1.CompareToOtherRow(row2).SameColour);
        }

        [Test]
        public void TestMoodyBlues() // TCA016
        {
            var row1 = new Row(Colour.Blue, Colour.Blue, Colour.Black, Colour.Black);
            var row2 = new Row(Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue);
            Assert.AreEqual(2, row1.CompareToOtherRow(row2).Same);
            Assert.AreEqual(0, row1.CompareToOtherRow(row2).SameColour);
        }

        [Test]
        public void TestHalfRight() // TCA017
        {
            var row1 = new Row(Colour.Blue, Colour.Red, Colour.Blue, Colour.Red);
            var row2 = new Row(Colour.Blue, Colour.Blue, Colour.Red, Colour.Red);
            Assert.AreEqual(2, row1.CompareToOtherRow(row2).Same);
            Assert.AreEqual(2, row1.CompareToOtherRow(row2).SameColour);
        }

        // <----- Mijn eigen testcases ----->

        [Test]
        public void TestCodeGenerationLogic() // TCA001
        {
            var game = new Game();
            var masterRow = game.MasterRow;

            Assert.AreEqual(4, masterRow.Pins.Length, "De geheime code moet uit vier kleuren bestaan.");
            Assert.That(masterRow.Pins, Is.All.InstanceOf<Pin>(), "De geheime code moet alleen Pin-objecten bevatten.");
            Assert.That(masterRow.Pins.All(pin => ((Pin)pin).Colour != Colour.None), "Elke Pin in de geheime code moet een geldige kleur bevatten.");
        }

        [Test]
        public void TestFeedbackPins() // TCA003
        {
            var row1 = new Row(Colour.Red, Colour.Blue, Colour.Green, Colour.Yellow);
            var row2 = new Row(Colour.Red, Colour.Green, Colour.Blue, Colour.Yellow);

            var feedback = row1.CompareToOtherRow(row2);

            Assert.AreEqual(2, feedback.Same, "Er moeten 2 pinnen met correcte posities zijn.");
            Assert.AreEqual(2, feedback.SameColour, "Er moeten 2 pinnen zijn met juiste kleuren maar verkeerde posities.");
        }

    }
}