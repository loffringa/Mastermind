namespace Mastermind.Models
{
    // @Todo: Deze interface moet nog een implementatie krijgen
    public interface IPin
    {
        // de kleur van de pin
        Colour Colour { get; }
        // de relatieve positie in de rij van de pin (1, 2, 3 of 4)
        int Position { get; }

        // Bepaalt of de andere en deze pin hetzelfde zijn (kleur en positie)
        bool Same(IPin other);
        // Bepaalt of de andere en deze pin dezelfde kleur hebben
        bool SameColour(IPin other);
    }
}