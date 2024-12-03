using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class Queen(Player color) : Piece
    {
        public override PieceType Type => PieceType.Queen;

        public override Player Color { get; } = color;

        private static readonly Direction[] dirs =
        [
           Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.SouthWest
        ];

        public override Piece Copy()
        {
            Queen copy = new(Color)
            {
                HasMoved = HasMoved
            };
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionInDirections(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
