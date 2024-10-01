namespace Mastermind.Models
{
    public class Pin : IPin
    {
        public Colour Colour { get; }
        public int Position { get; }

        public Pin(Colour colour, int position)
        {
            Colour = colour;
            Position = position;
        }

        public bool SameColour(IPin other)
        {
            return other.Colour == Colour;
        }

        public bool Same(IPin other)
        {
            return other.Colour == Colour
                && other.Position == Position;
        }
    }
}