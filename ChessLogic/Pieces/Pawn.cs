using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;

        public override Player Color { get; }
        private readonly Direction forward;
        public Pawn(Player color)
        {
            Color = color;
            switch (color)
            {
                case Player.White:
                    forward = Direction.North;
                    break;
                case Player.Black:
                    forward = Direction.South;
                    break;
            }
        }
        public override Piece Copy()
        {
            return new Pawn(Color)
            {
                HasMoved = HasMoved
            };
        }

        private static bool CanMoveTo(Position pos, Board board) => Board.IsInside(pos) && board.IsEmpty(pos);

        private bool CanCaptureAt(Position pos, Board board)
        {
            return Board.IsInside(pos) && !board.IsEmpty(pos) && board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMove(Position from, Board board)
        {
            Position oneMoveePos = from + forward;
            if (CanMoveTo(oneMoveePos, board))
            {
                yield return new NormalMove(from, oneMoveePos);
                Position twoMovesPos = oneMoveePos + forward;

                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new NormalMove(from, twoMovesPos);
                }
            }
        }

        public IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach(Direction dir in new Direction[] {Direction.East, Direction.West })
            {
                Position to = from + forward + dir;
                if(CanCaptureAt(to, board)){
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMove(from, board).Concat(DiagonalMoves(from, board));
        }
    }
}
