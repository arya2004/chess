using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Moves
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPosition { get; }
        public abstract Position ToPosition { get; }
        public abstract bool Execute(Board board);

        public virtual bool IsLegal(Board board)
        {
            Player player = board[FromPosition].Color;
            Board copu = board.CopyBoard();
            Execute(copu);
            return !copu.IsInCheck(player);
        }
    }

}
