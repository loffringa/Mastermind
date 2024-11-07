using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mastermind.Models
{
    public class Row : IRow
    {
        [MinLength(4)]
        [MaxLength(4)]
        public IPin[] Pins { get; }
        public Score Score { get; private set; }

        public Row(Colour c1 = Colour.None, Colour c2 = Colour.None, Colour c3 = Colour.None, Colour c4 = Colour.None)
        {
            Pins = new IPin[]
            {
                new Pin(c1, 1),
                new Pin(c2, 2),
                new Pin(c3, 3),
                new Pin(c4, 4)
            };
        }

        public bool IsValid()
        {
            // Kijken of de nummers van de pins precies 4 zijn of dat 1 kleur geen kleur heeft dus None
            return Pins.Length == 4 && Pins.All(pin => ((Pin)pin).Colour != Colour.None);
        }

        public Score CompareToOtherRow(IRow otherRow)
        {
            var otherpinsUsed = new bool[4]; // niets gebruikt nog
            var mypinsUsed = new bool[4]; // niets gebruikt nog
            var sameScore = 0;
            var colourOnlyScore = 0;

            // Eerst vergelijk je of de positie en kleur hetzelfde zijn
            for (var i = 0; i < 4; i++)
            {
                if (!Pins[i].Same(otherRow.Pins[i])) continue;
                mypinsUsed[i] = true;
                otherpinsUsed[i] = true;
                sameScore++;
            }

            // Vervolgens controleer je of de kleuren overeenkomen (zonder dezelfde positie)
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (mypinsUsed[i] || otherpinsUsed[j] || !Pins[i].SameColour(otherRow.Pins[j])) continue;
                    mypinsUsed[i] = true;
                    otherpinsUsed[j] = true;
                    colourOnlyScore++;
                }
            }

            return new Score(sameScore, colourOnlyScore); // Return both scores
        }
    }
}