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

        public Row(Colour c1, Colour c2, Colour c3, Colour c4)
        {
            Pins = new IPin[]
            {
                new Pin(c1, 1),
                new Pin(c2,2),
                new Pin(c3, 3),
                new Pin(c4, 4)
            };
        }

        public Score CompareToOtherRow(IRow otherRow)
        {
            var otherpinsUsed = new bool[4]; // niets gebruikt nog
            var mypinsUsed = new bool[4]; // niets gebruikt nog
            var sameScore = 0;
            var sameColourScore = 0;

            for (var i = 0; i<4; i++)
            {
                if (!Pins[i].Same(otherRow.Pins[i])) continue;
                mypinsUsed[i] = true;
                otherpinsUsed[i] = true;
                sameScore++;
            }

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (mypinsUsed[i] || otherpinsUsed[j] || !Pins[i].SameColour(otherRow.Pins[j])) continue;
                    mypinsUsed[i] = true;
                    otherpinsUsed[j] = true;
                    sameColourScore++;
                }
            }

            Score = new Score(sameScore, sameColourScore);
            return Score;
        }
    }
}