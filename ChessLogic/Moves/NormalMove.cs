using ChessLogic.Pieces;

namespace ChessLogic.Moves
{
    public class NormalMove : Move
    {
        public override MoveType Type => MoveType.Normal;

        public override Position FromPosition { get; }

        public override Position ToPosition { get; }

        public NormalMove(Position from, Position to)
        {
            this.ToPosition = to;
            this.FromPosition = from;
        }

        public override void Execute(Board board)
        {
            Piece piece = board[FromPosition];
            board[ToPosition] = piece;
            board[FromPosition] = null;
            piece.HasMoved = true;
        }
    }
}
