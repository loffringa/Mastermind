namespace Mastermind.Models
{
    // data-object om een score mee vast te leggen
    public class Score
    {
        public Score(int same, int sameColour)
        {
            Same = same;
            SameColour = sameColour;
        }

        // aantal pinnen dat exact hetzelfde is (positie in rij en kleur)
        public int Same { get; }
        // aantal pinnen dat dezelfde kleur heeft, maar een andere positie
        // let op, pinnen mogen niet dubbel geteld worden, Een pin die al meetelt voor Same kan niet ook gebruikt wordt voor SameColour
        // en een pin di al een keer gebruikt is voor SameColour mag niet ook nog eens gebruikt worden voor SameColour met een andere pin!
        public int SameColour { get; }
    }
}
