using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class Bishop(Player color) : Piece
    {
        public override PieceType Type => PieceType.Bishop;

        public override Player Color { get; } = color;

        private static readonly Direction[] dirs =
        [
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.SouthWest
        ];

        public override Piece Copy()
        {
            Bishop copy = new(Color)
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
