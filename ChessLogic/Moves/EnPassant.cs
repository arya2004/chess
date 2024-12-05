namespace ChessLogic.Moves
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.HolyHell;

        public override Position FromPosition { get; }

        public override Position ToPosition { get; }
        private readonly Position capturePos;

        public EnPassant(Position from, Position to)
        {
            FromPosition = from;
            ToPosition = to;
            capturePos = new Position(from.Row, to.Column);
        }

        public override bool Execute(Board board)
        {
            new NormalMove(FromPosition, ToPosition).Execute(board);
            board[capturePos] = null;

            return true;
        }
    }


}
