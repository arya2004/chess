using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class Rook(Player color) : Piece
    {
        public override PieceType Type => PieceType.Rook;

        public override Player Color { get; } = color;

        private static readonly Direction[] dirs =
        [
           Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        ];

        public override Piece Copy()
        {
            Rook copy = new(Color)
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
