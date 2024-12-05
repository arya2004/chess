using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Moves
{
    public class Castle : Move
    {
        public override MoveType Type { get; }

        public override Position FromPosition { get; }

        public override Position ToPosition { get; }

        private readonly Direction kingMoveDirection;
        private readonly Position rookFromPosition;
        private readonly Position rookToPosition;

        public Castle(MoveType tyoe, Position kingPos)
        {
            Type = tyoe;
            FromPosition = kingPos;
            if (tyoe == MoveType.CastleKingSide)
            {
                kingMoveDirection = Direction.East;
                ToPosition = new Position(kingPos.Row, 6);
                rookFromPosition = new Position(kingPos.Row, 7);
                rookToPosition = new Position(kingPos.Row, 5);
            }
            else if (tyoe == MoveType.CastleQueenSide)
            {
                kingMoveDirection = Direction.West;
                ToPosition = new Position(kingPos.Row, 2);
                rookFromPosition = new Position(kingPos.Row, 0);
                rookToPosition = new Position(kingPos.Row, 3);
            }
        }

        public override bool Execute(Board board)
        {
            new NormalMove(FromPosition, ToPosition).Execute(board);
            new NormalMove(rookFromPosition, rookToPosition).Execute(board);

            return false;

        }

        public override bool IsLegal(Board board)
        {
            Player player = board[FromPosition].Color;
            if (board.IsInCheck(player))
            {
                return false;
            }
            Board copu = board.CopyBoard();
            Position kingPositionInCoppy = FromPosition;

            for (int i = 0; i < 2; i++)
            {
                new NormalMove(kingPositionInCoppy, kingPositionInCoppy + kingMoveDirection).Execute(copu);
                kingPositionInCoppy += kingMoveDirection;

                if (copu.IsInCheck(player))
                {
                    return false;
                }

            }


            return true;

        }
    }
}
