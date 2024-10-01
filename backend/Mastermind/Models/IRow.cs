namespace Mastermind.Models
{
    // @Todo: Deze interface moet nog een implementatie krijgen
    public interface IRow
    {
        // geeft de pinnen van deze rij terug
        IPin[] Pins { get; }
        Score Score { get; }

        // bepaalt de score die de andere rij waard is, vergeleken met deze rij
        // dus als deze rij Rood, Rood, Blauw, Groen is en de andere rij is Rood Zwart, Groen, Zwart, dan is de score:
        // Same: 1, SameColour: 1
        // Zet het resultaat gelijk ook op de Property Score, anders komt het resultaat niet mee naar de frontend
        Score CompareToOtherRow(IRow otherRow);
    }
}