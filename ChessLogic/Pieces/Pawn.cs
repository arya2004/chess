namespace ChessLogic.Pieces
{
    public class Pawn(Player color) : Piece
    {
        public override PieceType Type => PieceType.Pawn;

        public override Player Color { get; } = color;

        public override Piece Copy()
        {
            Pawn copy = new(Color)
            {
                HasMoved = HasMoved
            };
            return copy;
        }
    }
}
