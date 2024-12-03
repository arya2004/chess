using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class Knight(Player color) : Piece
    {
        public override PieceType Type => PieceType.Knight;

        public override Player Color { get; } = color;

        public override Piece Copy()
        {
            Knight copy = new(Color)
            {
                HasMoved = HasMoved
            };
            return copy;
        }

        private  static IEnumerable<Position> PotentialToPosition(Position from)
        {
            foreach(Direction vDir in new Direction[] { Direction.North, Direction.South })
            {
                foreach(Direction hDir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovPositions(Position from, Board board)
        {
            return PotentialToPosition(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovPositions(from, board).Select(to => new NormalMove(from, to));
        }
    }
}
