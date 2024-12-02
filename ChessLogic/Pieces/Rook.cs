namespace ChessLogic.Pieces
{
    public class Rook(Player color) : Piece
    {
        public override PieceType Type => PieceType.Rook;

        public override Player Color { get; } = color;

        public override Piece Copy()
        {
            Rook copy = new(Color)
            {
                HasMoved = HasMoved
            };
            return copy;
        }
    }
}
