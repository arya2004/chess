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
                if(oneMoveePos.Row == 0 || oneMoveePos.Row == 7)
                {
                    foreach(Move m in PromotionMove(from, oneMoveePos))
                    {
                        yield return m;
                    }
                }
                else
                {
                    yield return new NormalMove(from, oneMoveePos);
                }

                
                Position twoMovesPos = oneMoveePos + forward;

                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new DoublePawn(from, twoMovesPos);
                }
            }
        }

        public IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach(Direction dir in new Direction[] {Direction.East, Direction.West })
            {
                Position to = from + forward + dir;

                if(to == board.GetPawnSkipPosition(Color.Opponent())){
                    yield return new EnPassant(from, to);
                }

                if(CanCaptureAt(to, board)){
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move m in PromotionMove(from, to))
                        {
                            yield return m;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMove(from, board).Concat(DiagonalMoves(from, board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPosition];
                return piece != null && piece.Type == PieceType.King;
            });
        }

        private static IEnumerable<Move> PromotionMove(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Queen);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Rook);
        }
    }
}
